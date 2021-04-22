using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumIncreasingSubSequence
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = MaxSumIncreasingSubsequence(new int[] { 10, 70, 20, 30, 50, 11, 30 });
			Console.ReadLine();
		}

		public static List<List<int>> MaxSumIncreasingSubsequence(int[] array)
		{
			// Write your code here.
			if (array.Length == 1)
			{
				return new List<List<int>> { new List<int> { array[0] }, new List<int> { array[0] } };
			}
			int len = array.Length;
			int[] sums = new int[len];
			for (int i = 0; i < len; i++)
			{
				sums[i] = array[i];
			}

			int[] sequences = new int[len];
			for (int i = 0; i < len; i++)
			{
				sequences[i] = int.MinValue;
			}

			int maxSumsIdx = 0;
			for (int i = 1; i < len; i++)
			{
				for (int k = 0; k < i; k++)
				{
					if (array[i] > array[k] && sums[k] + array[i] >= sums[i])
					{
						sums[i] = sums[k] + array[i];
						sequences[i] = k;
					}
				}
				if (sums[i] >= sums[maxSumsIdx])
				{
					maxSumsIdx = i;
				}
			}
			return new List<List<int>> { new List<int> { sums[maxSumsIdx] }, buildSequences(array, sequences, maxSumsIdx) };
		}

		private static List<int> buildSequences(int[] array, int[] sequences, int startIdx)
		{
			List<int> subSequenceList = new List<int>();
			while (startIdx != int.MinValue)
			{
				subSequenceList.Insert(0, array[startIdx]);
				startIdx = sequences[startIdx];
			}

			return  subSequenceList ;
		}
	}
}
