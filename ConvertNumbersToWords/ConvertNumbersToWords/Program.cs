using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertNumbersToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = NumberToWords(20);
            Console.ReadLine();
        }

        public static string NumberToWords(int num)
        {
            if(num == 0)
            {
                return "Zero";
            }
            string result = "";
            int billion = num / 1000000000;
            int remaining = num % 1000000000;
            int million = remaining / 1000000;
            remaining = remaining % 1000000;
            int thousand = remaining / 1000;
            int lastThreeDigits = remaining % 1000;

            if(billion != 0)
            {
                result = Threes(billion) + " Billion";
            }
            if (million != 0)
            {
                if(result != "")
                {
                    result = result + " ";
                }
                result = result + Threes(million) + " Million";
            }
            if (thousand != 0)
            {
                if (result != "")
                {
                    result = result + " ";
                }
                result = result + Threes(thousand) + " Thousand";
            }
            if (lastThreeDigits != 0)
            {
                if (result != "")
                {
                    result = result + " ";
                }
                result = result + Threes(lastThreeDigits) ;
            }

            return result;
        }

        private static string Threes(int num)
        {
            if(num == 0)
            {
                return "";
            }
            string result = "";
            int hundred = num / 100;
            int lastTwoDigits = num % 100;
            if(hundred != 0 && lastTwoDigits != 0)
            {
                result = Ones(hundred) + " Hundred " + Twos(lastTwoDigits);
            }
            else if (hundred != 0 && lastTwoDigits == 0)
            {
                result = Ones(hundred) + " Hundred";
            }
            else if (hundred == 0 && lastTwoDigits != 0)
            {
                result = Twos(lastTwoDigits);
            }

            return result;
        }

        private static string Twos(int num)
        {
            if(num == 0)
            {
                return "";
            }
            else if(num < 10)
            {
                return Ones(num);
            }
            else if (num < 20)
            {
                return TenToNineteen(num);
            }
            else
            {
                int twosPlace = num / 10;
                int onesPlace = num % 10;
                if(onesPlace == 0)
                {
                    return TwentyToNineties(twosPlace);
                }
                else
                {
                    return TwentyToNineties(twosPlace) + " " + Ones(onesPlace);
                }
            }      
        }

        private static string Ones(int num)
        {
            switch (num)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
            }
            return "";
        }

        private static string TenToNineteen(int num)
        {
            switch (num)
            {
                case 10: return "Ten";
                case 11: return "Eleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
            }
            return "";
        }

        private static string TwentyToNineties(int num)
        {
            switch (num)
            {
                case 2: return "Twenty";
                case 3: return "Thirty";
                case 4: return "Forty";
                case 5: return "Fifty";
                case 6: return "Sixty";
                case 7: return "Seventy";
                case 8: return "Eighty";
                case 9: return "Ninety";
            }
            return "";
        }
    }
}
