using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnagramsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = FindAnagrams("cbaebabacd", "abc");
            Console.ReadLine();
        }
        public static IList<int> FindAnagrams(string s, string p)
        {
            IList<int> output = new List<int>();
            if (s == null || s.Length == 0)
            {
                return output;
            }
            var newP = p.ToArray();
            Array.Sort(newP);
            for (int i = 0; i < s.Length - p.Length; i++)
            {
                if (FindAnagramsInString(s.Substring(i, p.Length), newP))
                {
                    output.Add(i);
                }
            }

            return output;

        }

        private static bool FindAnagramsInString(string s, char[] p)
        {
            var newS = s.ToArray();
            Array.Sort(newS);
            int i;
            for (i = 0; i < newS.Length; i++)
            {
                if (newS[i] != p[i])
                {
                    return false;
                }
            }

            return i == s.Length;

        }
    }
}
