using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qucikselect
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = Quickselect(new int[] { 8, 5, 2, 9, 7, 6, 3 }, 3) == 5;
			Console.ReadLine();

		}

		public static int Quickselect(int[] array, int k)
		{
			// Write your code here.
			// S.C is O(1) for all cases and
			// T.C is O(N) for best case
			// T.C is O(N) for average case
			// T.C is O(N^2) for worst case where N is the length of the array
			return Quickselect(array, 0, array.Length - 1, k - 1);
		}

		public static int Quickselect(int[] array, int start, int end, int position)
		{
			while (true)
			{
				if (start > end)
				{
					throw new Exception("Algorithm should Never arrive here");
				}
				int pivot = start;
				int left = start + 1;
				int right = end;
				while (left <= right)
				{
					if (array[left] > array[pivot] && array[right] < array[pivot])
					{
						swap(array, left, right);
					}
					if (array[left] <= array[pivot])
					{
						left++;
					}
					if (array[right] >= array[pivot])
					{
						right--;
					}
				}
				swap(array, pivot, right);
				if (right == position)
				{
					return array[right];
				}
				else if (right < position)
				{
					start = right + 1;
				}
				else
				{
					end = right - 1;
				}
			}
		}

		public static void swap(int[] array, int i, int j)
		{
			int temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}
	}
}
