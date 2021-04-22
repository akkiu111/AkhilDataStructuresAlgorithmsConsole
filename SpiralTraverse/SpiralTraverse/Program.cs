using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralTraverse
{
    class Program
    {
        static void Main(string[] args)
        {
			int[,] input = {
			{1, 2, 3},
			{12, 13, 14},
			{11, 16, 15},
			{22, 23, 24},
			{27, 28, 29},
		};
	
			var actual = Program.SpiralTraversing(input);
			Console.ReadLine();
		}

		public static List<int> SpiralTraversing(int[,] array)
		{
			// Write your code here.
			// T.C and S.C is O(N) where N is the no. of elements in input array
			if (array.GetLength(0) == 0)
			{
				return new List<int>();
			}
			int startRow = 0;
			int endRow = array.GetLength(0) - 1;
			int startCol = 0;
			int endCol = array.GetLength(1) - 1;
			var result = new List<int>();
			while (startRow <= endRow &&
						startCol <= endCol)
			{
				for (int col = startCol; col <= endCol; col++)
				{
					result.Add(array[startRow, col]);
				}

				for (int row = startRow + 1; row <= endRow; row++)
				{
					result.Add(array[row, endCol]);
				}

				for (int col = endCol - 1; col >= startCol; col--)
				{
					if (startRow == endRow)
					{
						break;
					}
					result.Add(array[endRow, col]);
				}
				for (int row = endRow - 1; row > startRow; row--)
				{
					if (startCol == endCol)
					{
						break;
					}
					result.Add(array[row, startCol]);
				}
				startRow++;
				endRow--;
				startCol++;
				endCol--;

			}
			return result;
		}
	}
}
