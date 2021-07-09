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

            var output = Merge(new int[][] { new int[] {2, 4 },
             new int[] {1, 3 }});
            Console.ReadLine();
        }

        public static int[][] Merge(int[][] windows)
        {
            // if (intervals == null || intervals.Length == 0)
            //     return new int[][] { };

            // List<int[]> result = new List<int[]>();

            // int[] Start = new int[intervals.Length];
            // for(int i = 0; i < intervals.Length; i++)
            // {
            //     Start[i] = intervals[i][0];
            // }
            // Array.Sort(Start);
            // int[] End = new int[intervals.Length];
            // for (int i = 0; i < intervals.Length; i++)
            // {
            //     End[i] = intervals[i][1];
            // }
            // Array.Sort(End);

            // int previousStart = Start[0];
            // int previousEnd = End[0];

            // for (int i = 1; i < intervals.Length; i++)
            // {
            //     int currentStart = Start[i];
            //     int currentEnd = End[i];
            //     if (currentStart > previousEnd)
            //     {
            //         result.Add(new int[] { previousStart, previousEnd });
            //         previousStart = currentStart;
            //     }

            //     previousEnd = currentEnd;

            // }

            // result.Add(new int[] { previousStart, previousEnd });

            // return result.ToArray();

            if (windows.Length == 0)
            {
                return new int[][] { };
            }
            List<int[]> output = new List<int[]>();
            int[] startIntervals = new int[windows.Length];
            int[] endIntervals = new int[windows.Length];
            for (int i = 0; i < windows.Length; i++)
            {
                startIntervals[i] = windows[i][0];
                endIntervals[i] = windows[i][1];
            }

            Array.Sort(startIntervals);

            int previousStart = startIntervals[0];
            int previousEnd = endIntervals[0];

            for (int i = 1; i < startIntervals.Length; i++)
            {

                int currentStart = startIntervals[i];
                int currentEnd = endIntervals[i];

                if (currentStart < previousEnd)
                {
                    previousEnd = Math.Max(currentEnd, previousEnd);
                }
                else
                {

                    output.Add(new int[] { previousStart, previousEnd });
                    previousStart = currentStart;
                    previousEnd = currentEnd;
                }
            }

            output.Add(new int[] { previousStart, previousEnd });
            return output.ToArray();
        }

    }

}
