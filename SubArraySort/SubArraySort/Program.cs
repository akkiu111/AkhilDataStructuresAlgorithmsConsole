using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = SubarraySort(new int[] {1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19});
			Console.ReadLine();
		}

		public static int[] SubarraySort(int[] array)
		{
			// Write your code here.
			int min = int.MaxValue;
			int max = int.MinValue;
			for (int i = 0; i < array.Length; i++)
			{
				int num = array[i];
				if (isOutOfOrder(i, num, array))
				{
					min = Math.Min(min, num);
					max = Math.Max(max, num);
				}
			}

			if (min == int.MaxValue || max == int.MinValue)
			{
				return new int[] { -1, -1 };
			}

			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] > min)
				{
					min = i;
					break;
				}
			}

			for (int i = array.Length - 1; i >= 0; i--)
			{
				if (array[i] < max)
				{
					max = i;
					break;
				}
			}

			return new int[] { min, max };
		}

		private static bool isOutOfOrder(int i, int num, int[] array)
		{
			if (i == 0)
			{
				return num > array[i + 1];
			}

			if (i == array.Length - 1)
			{
				return num < array[i - 1];
			}

			return num > array[i + 1] || num < array[i - 1];
		}
	}
}
