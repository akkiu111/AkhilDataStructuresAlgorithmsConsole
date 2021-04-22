using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsOneEditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = checkOneEditDistance("a", "ac");
            Console.ReadLine();
        }

        public static bool checkOneEditDistance(string s, string t)
        {
            int sLen = s.Length;
            int tLen = t.Length;

            if (Math.Abs(sLen - tLen) > 1)
            {
                return false;
            }

            if (sLen < tLen)
            {
               return checkOneEditDistance(t, s);
            }

            for (int i = 0; i < tLen; i++)
            {
                if (s[i] != t[i])
                {
                    if (sLen == tLen)
                    {
                        return TraverseSubString(s, t, i + 1, i + 1);
                    }

                    return TraverseSubString(s, t, i + 1, i);
                }
            }

            return sLen == tLen + 1;

        }

        public static bool TraverseSubString(string s, string t, int i, int j)
        {
            while (i < s.Length && j < t.Length && s[i] == t[j])
            {
                i++;
                j++;
            }

            return i == s.Length && j == t.Length;
        }
    }
}

