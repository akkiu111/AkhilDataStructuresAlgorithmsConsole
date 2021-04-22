using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLandingAndTakeOffMaxFlights
{
    class Program
    {
        static void Main(string[] args)
        {

            var output = maxFlights(new List<List<int>>{ new List<int> { 4,11},
            new List<int>{ 5,9},
            new List<int> {12,14},
            new List<int> {6,8 }});

        }

        private static int maxFlights(List<List<int>> flightsTimings)
        {
            //List<int> values = new List<int>();
            //for(int i = 0; i < flightsTimings.Count; i++)
            //{
            //    values.Add(1);
            //}

            //List<int> previous = flightsTimings[0];

            //for (int i = 1; i < flightsTimings.Count; i++)
            //{
            //    List<int> current = flightsTimings[i];
            //    if(previous[1] > current[0] && current[1] > previous[0])
            //    {
            //        values[i] = Math.Max(values[i - 1] + 1, values[i] + 1);
            //    }

            //    else
            //    {

            //        values[i] = values[i - 1];
            //    }

            //}

            //return values[values.Count - 1];

            int n = flightsTimings.Count;
            int[] starts = new int[n];
            int[] ends = new int[n];
            for (int i = 0; i < n; i++)
            {
                starts[i] = flightsTimings[i][0];
                ends[i] = flightsTimings[i][1];
            }
            Array.Sort(starts);
            Array.Sort(ends);
            int startIdx = 0, endIdx = 0, curr = 0, max = 0;
            while (startIdx < n)
            {
                if (starts[startIdx] < ends[endIdx])
                {
                    curr++;
                    startIdx++;
                }
                else
                {
                    curr--;
                    endIdx++;
                }
                max = Math.Max(max, curr);
            }
            return max;
        }
    }
}
