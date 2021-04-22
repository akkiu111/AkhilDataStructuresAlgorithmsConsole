using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderscorifyTheSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
			//string expected = "_test_this is a _testtest_ to see if _testestest_ it works";
			var output = UnderscorifySubstring(
				"ttttttttttttttbtttttctatawtatttttastvb", "ttt");
			Console.ReadLine();
		}

		public static string UnderscorifySubstring(string str, string substring)
		{
			// Write your code here.
			List<int[]> locations = modifyLocations(getLocations(str, substring));
			return buildUnderscorifyString(locations, str);
		}

		private static List<int[]> getLocations(string str, string substring)
		{
			int endIdx = 0;
			int subStartIdx = 0;
			List<int[]> locations = new List<int[]>();
			while (endIdx < str.Length)
			{
				while (endIdx < str.Length &&  subStartIdx < substring.Length &&
								str[endIdx] == substring[subStartIdx])
				{
					if (subStartIdx == substring.Length - 1)
					{
						locations.Add(new int[] { endIdx - subStartIdx, endIdx });
						break;
					}
					endIdx++;
					subStartIdx++;
				}
				if (subStartIdx != 0)
				{
					subStartIdx = 0;
				}
				else
				{
					endIdx++;
				}
			}

			return locations;
		}

		private static List<int[]> modifyLocations(List<int[]> locations)
		{
			List<int[]> modifiedLocations = new List<int[]>();
			if (locations.Count == 0)
			{
				return modifiedLocations;
			}
			int i = 1;
			int prevStartLocation = locations[0][0];
			int prevEndLocation = locations[0][1];
			while (i < locations.Count)
			{
				int currentStartLocation = locations[i][0];
				int currentEndLocation = locations[i][1];
				if (prevEndLocation != currentStartLocation &&
						prevEndLocation + 1 != currentStartLocation)
				{
					modifiedLocations.Add(new int[] { prevStartLocation, prevEndLocation });
					prevStartLocation = currentStartLocation;
				}
				prevEndLocation = currentEndLocation;
				i++;
			}
			modifiedLocations.Add(new int[] { prevStartLocation, prevEndLocation });

			return modifiedLocations;
		}

		private static string buildUnderscorifyString(List<int[]> locations, string str)
		{
			int startIdx = 0;
			int i = 0;
			StringBuilder sb = new StringBuilder();
			while (startIdx < str.Length && i < locations.Count)
			{
				while (startIdx < str.Length && startIdx != locations[i][0])
				{
					sb.Append(str[startIdx]);
					startIdx++;
				}
				sb.Append("_");
				while (startIdx < str.Length && startIdx != locations[i][1])
				{
					sb.Append(str[startIdx]);
					startIdx++;
				}
				sb.Append(str[startIdx]);
				sb.Append("_");
				i++;
				startIdx++;
			}

			while (startIdx < str.Length)
			{
				sb.Append(str[startIdx]);
				startIdx++;
			}

			return sb.ToString();
		}
	}
}
