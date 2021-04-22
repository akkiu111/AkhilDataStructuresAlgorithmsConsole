using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexMatchingDP
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = IsMatch("xaabyc", "*a*b.c");
            Console.ReadLine();
        }

        public static bool IsMatch(string s, string p)
        {
            bool[,] match = new bool[s.Length + 1, p.Length + 1];
            match[0, 0] = true;
            for (int j = 2; j <= p.Length; j++)
            {
                if (p[j - 1] == '*')
                {
                    match[0, j] = match[0, j - 2];
                }
            }

            for (int i = 1; i < match.GetLength(0); i++)
            {
                for (int j = 1; j < match.GetLength(1); j++)
                {
                    if (p[j - 1] == '.' || p[j - 1] == s[i - 1])
                    {
                        match[i, j] = match[i - 1, j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        match[i, j] = match[i, j - 2];
                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                        {
                            match[i, j] = match[i, j] || match[i - 1, j];
                        }
                    }
                    else
                    {
                        match[i, j] = false;
                    }
                }
            }

            return match[s.Length, p.Length];

        }
    }
}
