using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildFailures
{
    class Program
    {
        static void Main(string[] args)
        {
			var buildRuns = new List<List<bool>> {
			new List<bool> {
				true, true, true, false, false
			},
			new List<bool> {
				true, true, true, true, false
			},
			new List<bool> {
				true, true, true, true, true, true, false, false, false
			},
			new List<bool> {
				true, false, false, false, false, false
			},
			new List<bool> {
				true, true, true, true, true, true, true, true, true, true, true,
				true, false
			},
			new List<bool> {
				true, false
			},
			new List<bool> {
				true, true, true, true, false, false
			},
		};
			var output = Program.BuildFailures(buildRuns) == 3;
			Console.ReadLine();
		}


		public static int BuildFailures(List<List<bool>> buildRuns)
		{
			// Write your code here.
			List<decimal> percentList = new List<decimal>();
			foreach (var buildRun in buildRuns)
			{
				percentList.Add(calculateBuildRunPercent(buildRun));
			}

			return totalPercentDec(percentList);
		}

		private static int totalPercentDec(List<decimal> percentList)
		{
			int peak = 1;
			int maxPeak = int.MinValue;
			for (int i = 1; i < percentList.Count; i++)
			{
				if (percentList[i] < percentList[i - 1])
				{
					peak = peak + 1;
				}
				else
				{
					peak = 1;
				}

				maxPeak = Math.Max(maxPeak, peak);
			}

			if (maxPeak == 1)
			{
				return -1;
			}

			return maxPeak;
		}

		private static decimal calculateBuildRunPercent(List<bool> buildRun)
		{
			int num = 0;
			for (int i = 0; i < buildRun.Count; i++)
			{
				if (buildRun[i])
				{
					num = num +1;
				}
			}
			int den = buildRun.Count;
			decimal percent = (num * 100)/ den;
			return percent;
		}
	}

}
