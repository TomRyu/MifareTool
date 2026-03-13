using System;
using System.Linq;
using MifareTool.Class;

namespace MifareTool.Controls
{
    public class MifareReaderHelper
    {
        private readonly Func<byte[], (bool success, byte[] data, string error)> _transmitApdu;
        private readonly Action<string> _log;

        public MifareReaderHelper(
            Func<byte[], (bool success, byte[] data, string error)> transmitApdu,
            Action<string> log)
        {
            _transmitApdu = transmitApdu;
            _log = log;
        }

        public MifareDumpData ReadClassic1KDump()
        {
            var dump = new MifareDumpData();

            byte[] key = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

            var loadKey = _transmitApdu(
                new byte[] { 0xFF, 0x82, 0x00, 0x00, 0x06 }
                .Concat(key).ToArray());

            if (!loadKey.success)
                throw new Exception("Load Key 실패");

            _log?.Invoke("Load Key OK (FFFFFFFFFFFF)");

            for (int sector = 0; sector < 16; sector++)
            {
                var sectorData = new MifareDumpSector { SectorIndex = sector };

                // -------------------------------------------------------
                // 섹터 첫 블록으로 사용 가능한 키 타입 탐색
                // KeyA(0x60) 우선 시도 → 실패 시 KeyB(0x61) 폴백
                // -------------------------------------------------------
                int firstAbsBlock = sector * 4;
                byte workingKeyType = 0x60;

                var authA = _transmitApdu(new byte[]
                {
                    0xFF, 0x86, 0x00, 0x00, 0x05,
                    0x01, 0x00, (byte)firstAbsBlock, 0x60, 0x00
                });

                if (authA.success)
                {
                    workingKeyType = 0x60;
                    _log?.Invoke($"Auth KeyA 성공 Sector {sector}");
                }
                else
                {
                    _log?.Invoke($"Auth KeyA 실패 Sector {sector}: {authA.error} → KeyB 시도");

                    var authB = _transmitApdu(new byte[]
                    {
                        0xFF, 0x86, 0x00, 0x00, 0x05,
                        0x01, 0x00, (byte)firstAbsBlock, 0x61, 0x00
                    });

                    if (authB.success)
                    {
                        workingKeyType = 0x61;
                        _log?.Invoke($"Auth KeyB 성공 Sector {sector}");
                    }
                    else
                    {
                        _log?.Invoke($"Auth KeyB 실패 Sector {sector}: {authB.error} → 섹터 읽기 불가");
                        sectorData.ReadFailed = true;
                        dump.Sectors.Add(sectorData);
                        continue;
                    }
                }

                for (int blockInSector = 0; blockInSector < 4; blockInSector++)
                {
                    int absBlock = sector * 4 + blockInSector;

                    // 첫 블록은 이미 인증됨, 이후 블록은 재인증
                    if (blockInSector > 0)
                    {
                        var auth = _transmitApdu(new byte[]
                        {
                            0xFF, 0x86, 0x00, 0x00, 0x05,
                            0x01, 0x00, (byte)absBlock, workingKeyType, 0x00
                        });

                        if (!auth.success)
                            _log?.Invoke($"Auth 실패 Sector {sector} Block {blockInSector}: {auth.error}");
                    }

                    // 읽기
                    var read = _transmitApdu(new byte[]
                    {
                        0xFF, 0xB0, 0x00, (byte)absBlock, 0x10
                    });

                    byte[] data = new byte[16];
                    var unknownMask = new bool[16];

                    if (read.success && read.data != null && read.data.Length >= 16)
                    {
                        Array.Copy(read.data, 0, data, 0, 16);

                        // ---------------------------------------------------
                        // Trailer Block 표시 보정
                        // KeyA는 Mifare 스펙상 항상 00으로 반환됨
                        //   - KeyA로 인증한 경우: FFFFFFFFFFFF 복원 (알고 있는 키)
                        //   - KeyB로 인증한 경우: 실제 KeyA 불명 → UnknownMask로 "--" 표시
                        // KeyB가 00으로 반환되면 FFFFFFFFFFFF 복원 (사용한 키임이 확실)
                        // ---------------------------------------------------
                        if (blockInSector == 3)
                        {
                            bool keyAIsAllZero = true;
                            for (int i = 0; i < 6; i++)
                            {
                                if (data[i] != 0x00) { keyAIsAllZero = false; break; }
                            }

                            if (keyAIsAllZero)
                            {
                                if (workingKeyType == 0x60)
                                {
                                    // KeyA로 인증 성공 → FFFFFFFFFFFF로 복원
                                    Array.Copy(key, 0, data, 0, 6);
                                }
                                else
                                {
                                    // KeyB로 인증 → KeyA 실제 값 불명, "--" 표시
                                    for (int i = 0; i < 6; i++)
                                        unknownMask[i] = true;
                                }
                            }

                            bool keyBIsAllZero = true;
                            for (int i = 10; i < 16; i++)
                            {
                                if (data[i] != 0x00) { keyBIsAllZero = false; break; }
                            }

                            if (keyBIsAllZero)
                                Array.Copy(key, 0, data, 10, 6);
                        }

                        _log?.Invoke($"Sector {sector} Block {blockInSector} Read OK: {BitConverter.ToString(data).Replace("-", "")}");
                    }
                    else
                    {
                        _log?.Invoke($"Read 실패 Block {absBlock}: {read.error}");
                    }

                    sectorData.Blocks.Add(new MifareDumpBlock
                    {
                        SectorIndex = sector,
                        BlockIndexInSector = blockInSector,
                        AbsoluteBlockIndex = absBlock,
                        Data = data,
                        UnknownMask = unknownMask
                    });
                }

                dump.Sectors.Add(sectorData);
            }

            return dump;
        }
    }
}
