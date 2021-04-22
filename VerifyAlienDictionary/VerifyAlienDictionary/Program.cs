using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerifyAlienDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = IsAlienSorted(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz");
            Console.ReadLine();
        }

        public static int[] alphabets;
        public static bool IsAlienSorted(string[] words, string order)
        {
            alphabets = new int[26];
            for (int i = 0; i < order.Length; i++)
            {
                alphabets[order[i] - 'a'] = i;
            }

            for (int j = 1; j < words.Length; j++)
            {
                if (!Comparing(words[j - 1], words[j]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Comparing(string p, string q)
        {

            int i = 0;
            int j = 0;
            int compVal = 0;

            while (i < p.Length && j < q.Length && compVal == 0)
            {
                compVal = alphabets[p[i] - 'a'] - alphabets[q[j] - 'a'];
                if (compVal == 0)
                {
                    i++;
                    j++;
                    continue;
                }
                if (compVal > 0)
                {
                    return false;
                }

                i++;
                j++;
            }

            return compVal == 0 ? p.Length <= q.Length : compVal <= 0;


        }
    }
}
