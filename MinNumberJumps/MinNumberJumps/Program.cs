using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinNumberJumps
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static int minJumps(int[] array)
        {
            int jumps = 0;
            int steps = array[0];
            int maxReach = int.MinValue;
            for(int i = 0; i < array.Length; i++)
            {
                maxReach = Math.Max(maxReach, array[i] + i);
                steps = steps - 1;
                if(steps == 0)
                {
                    jumps = jumps + 1;
                    steps = maxReach - i;
                }

            }

            return steps != 0 ? jumps + 1: jumps ;
        }
    }
}
