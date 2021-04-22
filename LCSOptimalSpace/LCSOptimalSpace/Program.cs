using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCSOptimalSpace
{
    class Program
    {
        static void Main(string[] args)
        {
			//char[] expected = { 'X', 'Y', 'Z', 'W' };
			//var output = LongestCommonSubsequence("ABCDEFG", "ABCDEFG");
			Console.ReadLine();
		}

		//public static List<char> LongestCommonSubsequence(string str1, string str2)
		//{
		//	// Write your code here.

		//	int str1Length = str1.Length + 1;
		//	int str2Length = str2.Length + 1;

		//	if (str1Length > str2Length)
		//	{
		//		return LongestCommonSubsequence(str2, str1);
		//	}
			

		//	int[] odd = new int[str1Length];
		//	int[] even = new int[str1Length];
		//	int[] current;
		//	int[] previous;
		//	SequenceInfo[] sequence = new SequenceInfo[str1Length];

		//	for (int i = 0; i < str1Length; i++)
		//	{
		//		sequence[i] = new SequenceInfo(int.MinValue);
		//	}

		//	int previousIdxTrack = 0;
		//	int startSequenceIdx = 0;

		//	for (int i = 1; i < str2Length; i++)
		//	{
		//		if (i % 2 == 0)
		//		{
		//			current = even;
		//			previous = odd;
		//		}
		//		else
		//		{
		//			current = odd;
		//			previous = even;
		//		}

		//		current[0] = 0;

		//		for (int j = 1; j < str1Length; j++)
		//		{
		//			if (str1[j - 1] == str2[i - 1])
		//			{
		//				current[j] = previous[j - 1] + 1;
		//				sequence[j].currentStringIdx = j - 1;
		//				if (previousIdxTrack <= j - 1)
		//				{
		//					sequence[j].previousSequenceIdx = previousIdxTrack;
		//					previousIdxTrack = sequence[j].currentStringIdx + 1;
		//				}
		//				if(startSequenceIdx < j)
  //                      {
		//					startSequenceIdx = j;
		//				}
		//			}
		//			else
		//			{
		//				current[j] = Math.Max(current[j - 1], previous[j]);
		//			}
		//		}
		//	}

		//	int[] backTrackingArray = str2Length % 2 == 0 ? odd : even;
		//	return backTrack(str1, backTrackingArray, sequence, startSequenceIdx);

		//}

		//public class SequenceInfo
  //      {
		//	public int previousSequenceIdx;
		//	public int currentStringIdx;
		//	public SequenceInfo(int previousSequenceIdx, int currentStringIdx = 0)
  //          {
		//		this.previousSequenceIdx = previousSequenceIdx;
		//		this.currentStringIdx = currentStringIdx;
  //          }
  //      }

		//private static List<char> backTrack(string str, int[] backTrackingArray, SequenceInfo[] sequence, int index)
		//{
		//	List<char> output = new List<char>();
		//	while (sequence[index].previousSequenceIdx != int.MinValue)
		//	{
		//	    output.Add(str[sequence[index].currentStringIdx]);
		//		index = sequence[index].previousSequenceIdx;
		//	}

		//	return ReverseList(output);
		//}

		//private static List<char> ReverseList(List<char> output)
		//{
		//	int i = 0;
		//	int j = output.Count - 1;
		//	while (i < j)
		//	{
		//		char temp = output[i];
		//		output[i] = output[j];
		//		output[j] = temp;
		//		i++;
		//		j--;
		//	}
		//	return output;
		//}
	}
}
