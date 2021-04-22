using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPathSumMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
			var matrix = new List<List<int>>();
			matrix.Add(new List<int>(){
			1, 2, 4, 3, 2
		});
			matrix.Add(new List<int>(){
			7, 6, 5, 5, 1
		});
			matrix.Add(new List<int>(){
			8, 9, 7, 15, 14
		});
			matrix.Add(new List<int>(){
			5, 10, 11, 12, 13
		});
			var expected = 15;
			var actual =  LongestIncreasingMatrixPath(matrix);
			var output = expected == actual;
			Console.ReadLine();
		}

		public static int LongestIncreasingMatrixPath(List<List<int>> matrix)
		{
			// Write your code here.
			var longestPathLengthsMatrix = new List<List<int?>>();
			for (int i = 0; i < matrix.Count; i++)
			{
				var row = new List<int?>();
				for (int j = 0; j < matrix[0].Count; j++)
				{
					row.Add(null);
				}
				longestPathLengthsMatrix.Add(row);
			}

			var longestPath = 0;
			for (int i = 0; i < matrix.Count; i++)
			{
				for (int j = 0; j < matrix[0].Count; j++)
				{
					longestPath = Math.Max(longestPath, DFS(matrix, i, j, int.MinValue,
																									 longestPathLengthsMatrix));
				}
			}

			return longestPath;
		}

		private static int DFS(List<List<int>> matrix, int row, int col, int lastPathVal,
													List<List<int?>> longestPathLengthsMatrix)
		{
			bool isOutOfBounds = row < 0 || col < 0
				|| row >= matrix.Count || col >= matrix[0].Count;


			if (isOutOfBounds)
			{
				return 0;
			}
			int currentVal = matrix[row][col];
			if (currentVal <= lastPathVal)
			{
				return 0;
			}

			if (longestPathLengthsMatrix[row][col] == null)
			{
				int top = DFS(matrix, row - 1, col, currentVal, longestPathLengthsMatrix);
				int bottom = DFS(matrix, row + 1, col, currentVal, longestPathLengthsMatrix);
				int left = DFS(matrix, row, col - 1, currentVal, longestPathLengthsMatrix);
				int right = DFS(matrix, row, col + 1, currentVal, longestPathLengthsMatrix);
				longestPathLengthsMatrix[row][col] = 1 + Math.Max(Math.Max(top, bottom),
																														  Math.Max(left, right));
			}

			return (int)longestPathLengthsMatrix[row][col];
		}
	}
}
