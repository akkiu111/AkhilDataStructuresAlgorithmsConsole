using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = new string[] {"3141", "1512", "159", "793", "12412451", "8462643383279"};
            var output = getMinSpaces("3141592653589793238462643383279", numbers);
            Console.ReadLine();
        }

        private static int getMinSpaces(string pi, string[] numbers)
        {
            HashSet<string> numbersTable = new HashSet<string>();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbersTable.Add(numbers[i]);
            }

            Dictionary<int, int> cache = new Dictionary<int, int>();

            int minSpaces = getMinSpaces(pi, numbersTable, cache, 0);

            return minSpaces == int.MaxValue ? -1 : minSpaces;
        }

        private static int getMinSpaces(string pi, HashSet<string> numbersTable, Dictionary<int, int> cache, int idx)
        {
            if (idx == pi.Length)
            {
                return -1;
            }

            if (cache.ContainsKey(idx))
            {
                return cache[idx];
            }

            int minSpaces = int.MaxValue;
            for (int i = idx; i < pi.Length; i++)
            {
                string prefix = pi.Substring(idx, i - idx + 1);
                if (numbersTable.Contains(prefix))
                {
                    int minSpacesinSuffix = getMinSpaces(pi, numbersTable, cache, i + 1);

                    if (minSpaces == int.MaxValue)
                    {
                        minSpaces = Math.Min(minSpaces, minSpacesinSuffix);
                    }
                    else
                    {
                        minSpaces = Math.Min(minSpaces, minSpacesinSuffix + 1);
                    }
                }

            }

            cache[idx] = minSpaces;
            return cache[idx];

        }
    }
}
