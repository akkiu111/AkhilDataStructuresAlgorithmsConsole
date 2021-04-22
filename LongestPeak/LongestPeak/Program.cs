using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPeak
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = 6 == LongestPeak(new int[] { 1, 2, 3, 3, 4, 0, 10, 6, 5, -1, -3, 2, 3 });
			Console.ReadLine();

		}

		public static int LongestPeak(int[] array)
		{
			// Write your code here.
			if (array.Length < 2)
			{
				return 0;
			}
			int l = 0;
			int m = 1;
			int r = 2;
			int longestPeak = 0;
			int len = array.Length;
			while (r < len)
			{
				bool isPeak = array[m] > array[l] && array[m] > array[r];
				if (!isPeak)
				{
					l++;
					m++;
					r++;
					continue;
				}

				while (l > 0 && array[l] > array[l - 1])
				{
					l--;
				}

				while (r < len - 1 && array[r] > array[r + 1])
				{
					r++;
				}

				int currentPeak = r - l + 1;
				longestPeak = Math.Max(longestPeak, currentPeak);
				l = r;
				m = r + 1;
				r = r + 2;
			}
			return longestPeak;
		}
	}
}
