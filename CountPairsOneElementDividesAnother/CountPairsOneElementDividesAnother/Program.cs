using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPairsOneElementDividesAnother
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = countDivisiblePairs(new int[] { 1, 2, 3, 6, 12 });
            Console.ReadLine();
        }

        private static int countDivisiblePairs(int[] array)
        {
            int count = 0;
            int factors = 1;

            HashSet<int> numbers = new HashSet<int>();
            for(int i = 0; i < array.Length; i++)
            {
                numbers.Add(array[i]);
            }

            for (int i = 1; i < array.Length; i++)
            {
                int val = array[i];
                while(factors <= val/2)
                {
                    if ((val % factors == 0) && numbers.Contains(factors))
                    {
                        count++;
                    }
                    factors++;
                }

                factors = 1;

            }
            return count;
        }
    }
}
