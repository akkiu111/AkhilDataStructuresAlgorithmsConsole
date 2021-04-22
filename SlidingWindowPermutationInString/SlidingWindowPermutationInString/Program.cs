using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindowPermutationInString
{
    class Program
    {
        static void Main(string[] args)
        {
            var output =FindTotalAnagrams("cbaebabacd", "abc");
            Console.ReadLine();
        }

        public static int FindTotalAnagrams(string s, string p)
        {
            if (s == null || s.Length == 1 || p.Length > s.Length)
            {
                return 0;
            }
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            int uniqueLetters = 0;
            for (int j = 0; j < p.Length; j++)
            {
                char letter = p[j];
                if (!charCount.ContainsKey(letter))
                {
                    charCount.Add(letter, 0);
                    uniqueLetters++;
                }
                charCount[letter] = charCount[letter] + 1;
            }

            int comb = 0;
            int left = 0;
            int right = 0;
            while (right < s.Length)
            {
                char letter = s[right];
                if (charCount.ContainsKey(letter))
                {

                    charCount[letter] = charCount[letter] - 1;
                    if (charCount[letter] == 0)
                    {
                        uniqueLetters--;
                    }
                }


                while (uniqueLetters == 0)
                {
                    if (right - left + 1 == p.Length)
                    {
                        comb++;
                    }
                    letter = s[left];
                    if (charCount.ContainsKey(letter))
                    {

                        charCount[letter] = charCount[letter] + 1;
                        if (charCount[letter] > 0)
                        {
                            uniqueLetters++;
                        }
                    }
                    left++;

                }
                right++;
            }


            return comb;


        }
    }
}
