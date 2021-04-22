using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanToIntegerConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = RomanToInt("III");
            output = RomanToInt("MDCXCV");
            Console.ReadLine();
        }


        public static int RomanToInt(string s)
        {
            if (s == null)
            {
                return 0;
            }
            Dictionary<char, int> dict =
                ReplaceRomanWithEquivalentNumbersInDictionary("IVMCDLX");
            int i = 0;
            int sum = 0;
            while (i < s.Length)
            {
                int curr = dict[s[i]];

                if (i + 1 < s.Length && curr < dict[s[i + 1]])
                {
                    sum = sum + dict[s[i + 1]] - curr;
                    i = i + 2;
                }
                else
                {
                    sum = sum + curr;
                    i++;
                }
            }

            return sum;
        }

        private static Dictionary<char, int> ReplaceRomanWithEquivalentNumbersInDictionary(string roman)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char letter in roman)
            {
                if (letter == 'I')
                {
                    dict.Add('I', 1);
                }
                else if (letter == 'V')
                {
                    dict.Add('V', 5);
                }
                else if (letter == 'X')
                {
                    dict.Add('X', 10);
                }
                else if (letter == 'L')
                {
                    dict.Add('L', 50);
                }
                else if (letter == 'C')
                {
                    dict.Add('C', 100);
                }
                else if (letter == 'D')
                {
                    dict.Add('D', 500);
                }
                else if (letter == 'M')
                {
                    dict.Add('M', 1000);
                }
            }

            return dict;
        }

        //public static  int RomanToInt(string s)
        //{
        //    if (s == null)
        //    {
        //        return 0;
        //    }
        //    Dictionary<char, int> dict = ReplaceRomanWithEquivalentNumbersInDictionary("IVMCDLX");
        //    int prevIdx = 0;
        //    int currIdx = 1;
        //    int sum = 0;
        //    while (prevIdx < s.Length && currIdx < s.Length)
        //    {
        //        char prev = s[prevIdx];
        //        char curr = s[currIdx];
        //        if (prev == 'I')
        //        {
        //            if (curr == 'X' || curr == 'V')
        //            {
        //                sum = sum + dict[curr] - dict[prev];
        //                prevIdx = prevIdx + 2;
        //                currIdx = currIdx + 2;

        //            }
        //            else
        //            {
        //                sum = sum + dict[prev];
        //                prevIdx++;
        //                currIdx++;
        //            }
        //        }
        //        else if (prev == 'X')
        //        {
        //            if (curr == 'L' || curr == 'C')
        //            {
        //                sum = sum + dict[curr] - dict[prev];
        //                prevIdx = prevIdx + 2;
        //                currIdx = currIdx + 2;
        //            }
        //            else
        //            {
        //                sum = sum + dict[prev];
        //                prevIdx++;
        //                currIdx++;
        //            }
        //        }
        //        else if (prev == 'C')
        //        {
        //            if (curr == 'M' || curr == 'D')
        //            {
        //                sum = sum + dict[curr] - dict[prev];
        //                prevIdx = prevIdx + 2;
        //                currIdx = currIdx + 2;
        //            }
        //            else
        //            {
        //                sum = sum + dict[prev];
        //                prevIdx++;
        //                currIdx++;
        //            }
        //        }
        //        else
        //        {
        //            sum = sum + dict[prev];
        //            prevIdx++;
        //            currIdx++;
        //        }
        //    }

        //    if (prevIdx == s.Length - 1)
        //    {
        //        sum = sum + dict[s[prevIdx]];
        //    }

        //    return sum;
        //}

        //private static Dictionary<char, int> ReplaceRomanWithEquivalentNumbersInDictionary(string roman)
        //{
        //    Dictionary<char, int> dict = new Dictionary<char, int>();
        //    foreach (char letter in roman)
        //    {
        //        if (letter == 'I')
        //        {
        //            dict.Add('I', 1);
        //        }
        //        else if (letter == 'V')
        //        {
        //            dict.Add('V', 5);
        //        }
        //        else if (letter == 'X')
        //        {
        //            dict.Add('X', 10);
        //        }
        //        else if (letter == 'L')
        //        {
        //            dict.Add('L', 50);
        //        }
        //        else if (letter == 'C')
        //        {
        //            dict.Add('C', 100);
        //        }
        //        else if (letter == 'D')
        //        {
        //            dict.Add('D', 500);
        //        }
        //        else if (letter == 'M')
        //        {
        //            dict.Add('M', 1000);
        //        }
        //    }

        //    return dict;
        //}
    }
}
