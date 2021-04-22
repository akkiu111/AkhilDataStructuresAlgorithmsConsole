using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestSubstringContaining
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigstring = "a$fuu+afff+affaffa+a$Affab+a+a+$a$";
            string smallstring = "a+$aaAaaaa$++";
            string expected = "affa+a$Affab+a+a+$a";
            //string bigstring = "abcd$ef$axb$c$";
            //string smallstring = "$$abf";
            //string expected = "f$axb$";

            var output = SmallestSubstringContaining(bigstring, smallstring);
            var isTrue = expected == output;
            Console.ReadLine();
        }

        public static string SmallestSubstringContaining(string bigstring, string smallstring)
        {
            // Write your code here.
            Dictionary<char, int> mainDictionary = new Dictionary<char, int>();
            int totalUniqueChars = getTotalUniqueChars(mainDictionary, smallstring);
            Dictionary<char, int> currentDictionary = new Dictionary<char, int>();
            int left = 0;
            int right = 0;
            int currentChars = 0;
            int maxLeft = 0;
            int maxRight = int.MaxValue;
            while (right < bigstring.Length)
            {

                char ch = bigstring[right];
                if (!mainDictionary.ContainsKey(ch))
                {
                    right++;
                    continue;
                }
                else
                {

                    if (!currentDictionary.ContainsKey(ch))
                    {
                        currentDictionary.Add(ch, 1);
                    }
                    else
                    {
                        currentDictionary[ch] = currentDictionary[ch] + 1;
                    }
                    if (currentDictionary[ch] == mainDictionary[ch])
                    {
                        currentChars += 1;
                    }
                }

                while (currentChars == totalUniqueChars && left <= right)
                {
                    if (right - left < maxRight - maxLeft)
                    {
                        maxRight = right;
                        maxLeft = left;
                    }

                    ch = bigstring[left];
                    if (!currentDictionary.ContainsKey(ch))
                    {
                        left++;
                        continue;
                    }
                    else
                    {
                        if (currentDictionary[ch] == mainDictionary[ch])
                        {
                            currentChars--;
                        }
                        currentDictionary[ch] = currentDictionary[ch] - 1;
                    }

                    left++;
                }
                right ++;
            }

            return maxRight == int.MaxValue ? "" : bigstring.Substring(maxLeft, maxRight - maxLeft + 1);
        }

        private static int getTotalUniqueChars(Dictionary<char, int> mainDictionary, string smallstring)
        {
            int totalUniqueChars = 0;
            for (int i = 0; i < smallstring.Length; i++)
            {
                char ch = smallstring[i];
                if (!mainDictionary.ContainsKey(ch))
                {
                    mainDictionary.Add(ch, 1);
                    totalUniqueChars += 1;
                }
                else
                {
                    mainDictionary[ch] += 1;
                }
            }

            return totalUniqueChars;
        }
    }
}
