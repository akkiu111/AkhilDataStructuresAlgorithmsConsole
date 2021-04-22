using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthSum
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = FourNumberSum(new int[] { 7, 6, 4, -1, 1, 2 }, 16);
			Console.ReadLine();

		}

		public static List<int[]> FourNumberSum(int[] array, int targetSum)
		{
			// Write your code here.
			Dictionary<int, List<int[]>> numbers = new Dictionary<int, List<int[]>>();

			List<int[]> fours = new List<int[]>();

			for (int i = 1; i < array.Length - 1; i++)
			{
				for (int j = i + 1; j < array.Length; j++)
				{
					int diff = targetSum - (array[i] + array[j]);
					if (numbers.ContainsKey(diff))
					{
						foreach (int[] pair in numbers[diff])
						{
							fours.Add(new int[] { pair[0], pair[1], array[i], array[j] });
						}
					}

				}

				int k = 0;
				while (k < i)
				{
					int sum = array[k] + array[i];
					if (!numbers.ContainsKey(sum))
					{
                        numbers.Add(sum, new List<int[]>
						{
							new int[] { array[k], array[i] }
						});
					}
					else
					{
						numbers[sum].Add(new int[] { array[k], array[i] });
					}
					k++;
				}


			}
			return fours;
		}
	}
}
