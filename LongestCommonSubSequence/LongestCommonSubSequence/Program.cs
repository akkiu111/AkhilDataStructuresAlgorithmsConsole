using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubSequence
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = LongestCommonSubsequence("ZXCYWZK", "XKVVYWZ");
			Console.ReadLine();
		}

		public static List<char> LongestCommonSubsequence(string str1, string str2)
		{
			// Write your code here.

			int[,] com = new int[str2.Length + 1, str1.Length + 1];
			for (int row = 1; row < str2.Length + 1; row++)
			{
				for (int col = 1; col < str1.Length + 1; col++)
				{
					if (str2[row - 1] == str1[col - 1])
					{
						com[row, col] = com[row - 1, col - 1] + 1;
					}
					else
					{
						com[row, col] = Math.Max(com[row - 1, col], com[row, col - 1]);
					}
				}
			}

			return buildSequence(str1, str2, com);
		}

		private static List<char> buildSequence(string str1, string str2, int[,] com)
		{
			List<char> sequence = new List<char>();
			int row = str2.Length;
			int col = str1.Length;
			while (row > 0 && col > 0)
			{
				if (com[row, col] == com[row - 1, col])
				{
					row = row - 1;
				}
				else if (com[row, col] == com[row, col - 1])
				{
					col = col - 1;
				}
				else
				{
					row = row - 1;
					col = col - 1;
					sequence.Insert(0, str1[col]);
				}
			}

			return sequence;
		}
	}
}
