using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleCycleCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = HasSingleCycle(new int[] { 2, 3, -2, -4, -4, 2 });
            Console.ReadLine();
        }

        private static bool HasSingleCycle(int[] array)
        {
            int index = 0;
            int count = 0;
            while(count < array.Length)
            {
                if (count > 0 && index == 0)
                {
                    return false;
                }
                count++;
                index = getNextIndex(array, index);

            }

            return index == 0;
        }

        private static int getNextIndex(int[] array, int index)
        {
            int jump = array[index];
            index = (index + jump) % (array.Length);
            return index >= 0 ? index : index + array.Length;
        }
    }
}
