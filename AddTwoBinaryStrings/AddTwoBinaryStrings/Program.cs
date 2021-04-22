using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace AddTwoBinaryStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var output1 = AddBinary("10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101"
, "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011");
            var output2 = AddBinaryStrings("10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101"
, "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011");
            //Output = 100
            Console.ReadLine();
        }


        public static string AddBinaryStrings(string a, string b)
        {
            StringBuilder res = new StringBuilder();
            int i = a.Length - 1, j = b.Length - 1;
            int carry = 0;
            while (i >= 0 || j >= 0 || carry > 0)
            {
                int num1 = i >= 0 && a[i] == '1' ? 1 : 0;
                int num2 = j >= 0 && b[j] == '1' ? 1 : 0;
                int bit = (num1 ^ num2) ^ carry;
                carry = (num1 & num2) == 1 || ((num1 | num2) == 1 && carry == 1) ? 1 : 0;
                res.Insert(0, bit.ToString());
                i--;
                j--;
            }

            return res.ToString();
        }

        public static string AddBinary(string a, string b)
        {
            BigInteger x = BigInteger.Parse(BinToDec(a));
            BigInteger y = BigInteger.Parse(BinToDec(b));
            BigInteger carry = 0;
            BigInteger answer = 0;
            while (y != 0)
            {
                carry = x & y;
                answer = x ^ y;
                y = carry << 1;
                x = answer;
            }


            return DecToBin(x);
        }

        public static string BinToDec(string value)
        {
            // BigInteger can be found in the System.Numerics dll
            BigInteger res = 0;

            // I'm totally skipping error handling here
            foreach (char c in value)
            {
                res <<= 1;
                res += c == '1' ? 1 : 0;
            }

            return res.ToString();
        }

        public static string DecToBin(BigInteger decVal)
        {
            string a = "";
            while (decVal >= 1)
            {
                a = a + (decVal % 2).ToString();
                decVal = decVal / 2;
            }
            string binValue = "";
            for (int i = a.Length - 1; i >= 0; i--)
            {
                binValue = binValue + a[i];
            }

            return binValue;
        }
    }
}
