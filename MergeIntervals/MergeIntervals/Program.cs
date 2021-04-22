using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = MergeInterval(new int[2][] { new int[] { 1, 4 }, new int[] { 0, 0 } });
            Console.ReadLine();
        }

        public static int[][] MergeInterval(int[][] intervals)
        {

            int[] starts = new int[intervals.Length];
            int[] ends = new int[intervals.Length];

            for (int m = 0; m < intervals.Length; m++)
            {
                starts[m] = intervals[m][0];
                ends[m] = intervals[m][1];
            }

            Array.Sort(starts);
            Array.Sort(ends);
            int i = 0;
            int j = 0;
            int count = 0;
            int minInterval = int.MaxValue;
            int maxInterval = int.MinValue;
            List<int[]> output = new List<int[]>();
            while (i < starts.Length && j < ends.Length)
            {
                if (starts[i] <= ends[j])
                {
                    minInterval = Math.Min(i, minInterval);
                    count++;
                    i++;
                }
                else
                {
                    maxInterval = Math.Max(j, maxInterval);
                    if (starts[i] != ends[j])
                    {
                        count--;
                    }
                    j++;
                }

                if (count == 0)
                {
                    output.Add(new int[] { starts[minInterval], ends[maxInterval] });
                    minInterval = int.MaxValue;
                    maxInterval = int.MinValue;
                }
            }

            if (count != 0)
            {
                output.Add(new int[] { starts[minInterval], ends[ends.Length - 1] });
            }

            return output.ToArray();
        }
    }
}
