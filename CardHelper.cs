using System;
using System.Text;

namespace MifareTool
{
    public enum Card
    {
        GUEST = 3, // 3
        CLEAN,     // 4
        CHECK,     // 5
        INSTALL    // 6
    }
    public enum Card2
    {
        EMPTY, 
        GUEST,
        STAFF,
        URGENT, 
        PASSWORD, 
        ROOMNUM
    }
    public class CardHelper
    {
        /// <summary>
        /// Java getTMRCardType(String sUID, String sSector2) -> C#
        /// sUID: (hex string)
        /// sSector2: (hex string, 최소 12자 이상 필요)
        /// </summary>
        public Card GetTMRCardType(string sUID, string sSector2)
        {
            // Java: int nUID = Integer.parseInt(Common.hex2Dec(sUID));
            // Java: int nBuf6 = Integer.parseInt(Common.hex2Dec(sSector2.substring(10,12)));
            int nUID = HexToInt(sUID);
            int nBuf6 = HexToInt(sSector2.Substring(10, 2));

            // Java: nRand[0..4] = sector2[0..10] (2자리씩)
            int[] nRand = new int[5];
            nRand[0] = HexToInt(sSector2.Substring(0, 2));
            nRand[1] = HexToInt(sSector2.Substring(2, 2));
            nRand[2] = HexToInt(sSector2.Substring(4, 2));
            nRand[3] = HexToInt(sSector2.Substring(6, 2));
            nRand[4] = HexToInt(sSector2.Substring(8, 2));

            int temp = nUID + nRand[0];
            temp = temp ^ nRand[1];
            temp = temp ^ nRand[2];
            temp = temp ^ nRand[3];
            temp = temp ^ nRand[4];

            // Java: String result = String.format("%08d", Integer.parseInt(Integer.toBinaryString(temp)));
            // 주의: 이 코드는 "이진 문자열"을 int로 해석 후 8자리 10진수로 패딩하는 약간 특이한 로직입니다.
            // 예) temp=5 -> toBinaryString="101" -> parseInt=101 -> format -> "00000101"
            string binaryDigitsAsDecimal = Convert.ToString(temp, 2);   // "10101" 같은 형태
            int parsedAsDecimal = int.Parse(binaryDigitsAsDecimal);     // 10101 (십진수)
            string result = parsedAsDecimal.ToString("D8");             // 8자리 0패딩

            // Java: binaryString += (result.charAt(n) == '1') ? '0' : '1';
            var sb = new StringBuilder(result.Length);
            for (int n = 0; n < result.Length; n++)
            {
                sb.Append(result[n] == '1' ? '0' : '1');
            }
            string binaryString = sb.ToString();

            // Java: double convertedDouble = 0; ... pow(2, len) ...
            // C#에서는 int/long으로 계산해도 되지만, 원 코드 그대로 double로 유지
            double convertedDouble = 0;
            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == '1')
                {
                    int len = binaryString.Length - 1 - i;
                    convertedDouble += Math.Pow(2, len);
                }
            }
            temp = (int)convertedDouble;

            // Java: CardType ct = CardType.EMPTY; (실제 사용 안함) -> 제거 가능
            Card cardType = new Card();
            if (temp + 3 == nBuf6)
            {
                cardType = Card.GUEST;
            }
            else if (temp + 4 == nBuf6)
            {
                cardType = Card.CLEAN;
            }
            else if (temp + 5 == nBuf6)
            {
                cardType = Card.CHECK;
            }
            else if (temp + 6 == nBuf6)
            {
                cardType = Card.INSTALL;
            }

            return cardType;
        }
        public (Card2 cardType, string[] roomNum, string[] systemId) GetTMRCardType2(string sBlock)
        {
            string sCardType = sBlock.Substring(0, 2).ToUpper();
            string[] roomNum =
            {
                sBlock.Substring(2, 2),
                sBlock.Substring(4, 2),
                sBlock.Substring(6, 2)
            }; 
            string[] systemId =
            {
                sBlock.Substring(22, 2),
                sBlock.Substring(24, 2),
                sBlock.Substring(26, 2)
            };

            Card2 cardType = new Card2();
            switch (sCardType)
            {
                case "FF"://Empty
                    cardType = Card2.EMPTY;
                    break;
                case "C1"://Guest
                    cardType = Card2.GUEST;
                    break;
                case "C2"://Staff
                    cardType = Card2.STAFF;
                    break;
                case "C3"://Urgent
                    cardType = Card2.URGENT;
                    break;
                case "C4"://Password
                    cardType = Card2.PASSWORD;
                    break;
                case "C5"://RoomNumber
                    cardType = Card2.ROOMNUM;
                    break;
                default:
                    break;
            }

            return (cardType, roomNum, systemId);
        }

        public string SetTMRCardType(Card cardType, byte[] tagId)
        {
            // tagId == Common.getTag().getId() 에 해당
            // Java: bytes2Hex(id).substring(0,2) -> UID 첫 바이트(2 hex)
            if (tagId == null || tagId.Length == 0)
                return "";

            // UID 첫 바이트를 16진수 2자리 문자열로 만든 뒤, 10진수로 변환
            string sUID = tagId[0].ToString("X2");   // Java substring(0,2)와 동일 효과
            int nUID = Convert.ToInt32(sUID, 16);    // Java hex2Dec + parseInt

            // 난수 5개 생성 (generateInt()는 0~255 범위라고 가정)
            int[] nRand = new int[5];
            for (int i = 0; i < 5; i++)
                nRand[i] = GenerateInt(); // TODO: 아래 GenerateInt 구현/교체

            // sRandom = 5바이트를 2자리 HEX로 연결
            string sRandom = "";
            for (int i = 0; i < 5; i++)
                sRandom += nRand[i].ToString("X2");

            // temp 계산
            int temp = nUID + nRand[0];
            temp ^= nRand[1];
            temp ^= nRand[2];
            temp ^= nRand[3];
            temp ^= nRand[4];

            // ===== 원본 Java의 "이상한" 변환을 그대로 재현 =====
            // Java:
            // String result = String.format("%08d", Integer.parseInt(Integer.toBinaryString(temp)));
            // -> binary string(예:"101")을 10진수 숫자 101로 파싱 후 8자리 '0'패딩
            string bin = Convert.ToString(temp, 2); // Integer.toBinaryString
            int parsedDecimalFromBinaryDigits = int.Parse(bin); // "101" -> 101 (base10)
            string result = parsedDecimalFromBinaryDigits.ToString("D8"); // %08d

            // bit 반전(문자 '1'->'0', 그 외->'1')
            char[] inverted = new char[result.Length];
            for (int i = 0; i < result.Length; i++)
                inverted[i] = (result[i] == '1') ? '0' : '1';

            string binaryString = new string(inverted);

            // binaryString을 2진수로 해석해서 temp로 변환
            // (원본은 double로 pow를 써서 계산했지만 int로 안전하게 계산 가능)
            int converted = 0;
            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == '1')
                {
                    int len = binaryString.Length - 1 - i;
                    converted += (1 << len);
                }
            }
            temp = converted;
            // ==============================================

            // cardType 더하기
            temp += (int)cardType;

            // 최종 문자열: sRandom + temp 2자리 HEX + 뒤 20바이트(?) 0 padding
            // Java: "00000000000000000000" (20 chars)
            string sReturn = sRandom + temp.ToString("X2") + "00000000000000000000";
            return sReturn;
        }

        // 예시 generateInt(): 0~255
        private static readonly Random _rng = new Random();
        private int GenerateInt()
        {
            return _rng.Next(0, 256);
        }


        /// <summary>
        /// hex 문자열을 int로 변환 (공백/하이픈 제거 등 필요하면 여기에서 처리)
        /// </summary>
        private int HexToInt(string hex)
        {
            if (hex == null) throw new ArgumentNullException(nameof(hex));
            hex = hex.Trim().Replace(" ", "").Replace("-", "");
            return Convert.ToInt32(hex, 16);
        }
    }
}
