using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadanesAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = KadanesAlgorithmValue(new int[] { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 });
			Console.ReadLine();
        }
		public static int KadanesAlgorithmValue(int[] array)
		{
			// Write your code here.

			if (array.Length == 0)
			{
				return 0;
			}

			if (array.Length == 1)
			{
				return array[0];
			}
			int l = 0;
			int r = 1;
			while (r < array.Length)
			{
				if (array[r] + array[l] < array[r])
				{
					l = r-1;
				}
				else
				{
					array[r] = array[r] + array[l];
				}
				l++;
				r++;
			}

			int m = 0;
			int max = int.MinValue;
			while (m < array.Length)
			{
				max = Math.Max(array[m], max);
				m++;
			}
			return max;
		}
	}
}
