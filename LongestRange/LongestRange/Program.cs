using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestRange
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = LargestRange(new int[] { 19, -1, 18, 17, 2, 10, 3, 12, 5, 16, 4, 11, 8, 7, 6, 15,
	12, 12, 2, 1, 6, 13, 14});
			Console.ReadLine();
		}

		public static int[] LargestRange(int[] array)
		{
			// Write your code here.

			Dictionary<int, bool> numbers = new Dictionary<int, bool>();
			for (int i = 0; i < array.Length; i++)
			{
				if (!numbers.ContainsKey(array[i]))
				{
					numbers.Add(array[i], true);
				}
			}
			int longestLength = 0;
			int maxLeft = array[0];
			int maxRight = array[0];
			for (int i = 0; i < array.Length; i++)
			{
				int num = array[i];
				if (!numbers[num])
				{
					continue;
				}
				int currentLength = 1;
				numbers[num] = false;
				int left = num - 1;
				while (numbers.ContainsKey(left) && numbers[left])
				{
					numbers[left] = false;
					left = left - 1;
					currentLength++;
				}

				int right = num + 1;
				while (numbers.ContainsKey(right) && numbers[right])
				{
					numbers[right] = false;
					right = right + 1;
					currentLength++;
				}

				if (currentLength > longestLength)
				{
					maxRight = right - 1;
					maxLeft = left + 1;
					longestLength = currentLength;
				}
			}
			return new int[] { maxLeft, maxRight };
		}
	}
}
