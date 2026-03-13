using System;
using System.Collections.Generic;

namespace MifareTool.Class
{
    public class MifareDumpBlock
    {
        public int SectorIndex { get; set; }
        public int BlockIndexInSector { get; set; }
        public int AbsoluteBlockIndex { get; set; }
        public byte[] Data { get; set; } = new byte[16];

        // 화면 표시용: true이면 해당 바이트는 "--"로 표시
        public bool[] UnknownMask { get; set; } = new bool[16];

        public bool IsTrailerBlock
        {
            get { return BlockIndexInSector == 3; }
        }

        public bool IsSector0Block0
        {
            get { return SectorIndex == 0 && BlockIndexInSector == 0; }
        }
    }

    public class MifareDumpSector
    {
        public int SectorIndex { get; set; }
        public List<MifareDumpBlock> Blocks { get; set; } = new List<MifareDumpBlock>();
        public bool ReadFailed { get; set; } = false;
    }

    public class MifareDumpData
    {
        public List<MifareDumpSector> Sectors { get; set; } = new List<MifareDumpSector>();
    }
}
