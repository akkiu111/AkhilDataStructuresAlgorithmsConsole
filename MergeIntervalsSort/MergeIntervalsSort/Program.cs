using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeIntervalsSort
{
    class Program
    {
        static void Main(string[] args)
        {

            var output = Merge(new int[][] { new int[] {1, 4 },
             new int[] {2, 3 }});
        }

        public static int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return new int[][] { };

            List<int[]> result = new List<int[]>();

            int[] Start = new int[intervals.Length];
            for(int i = 0; i < intervals.Length; i++)
            {
                Start[i] = intervals[i][0];
            }
            Array.Sort(Start);
            int[] End = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                End[i] = intervals[i][1];
            }
            Array.Sort(End);

            int previousStart = Start[0];
            int previousEnd = End[0];

            for (int i = 1; i < intervals.Length; i++)
            {
                int currentStart = Start[i];
                int currentEnd = End[i];
                if (currentStart > previousEnd)
                {
                    result.Add(new int[] { previousStart, previousEnd });
                    previousStart = currentStart;
                }

                previousEnd = currentEnd;

            }

            result.Add(new int[] { previousStart, previousEnd });

            return result.ToArray();
        }

    }

}
