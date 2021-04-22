using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskStacking
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = DiskStacking(new List<int[]> { new int[] { 2, 1, 2 },
														new int[] { 3, 2, 3 },
														new int[] { 2, 2, 8 },
														new int[] { 2, 3, 4 },
														new int[] { 1, 3, 1 },
														new int[] { 4, 4, 5 }
			});

			Console.ReadLine();

		}
		public static List<int[]> DiskStacking(List<int[]> disks)
		{
			// Write your code here.

			disks.Sort((disk1, disk2) => disk1[2].CompareTo(disk2[2]));
			int len = disks.Count;
			int[] heights = new int[len];
			for (int i = 0; i < len; i++)
			{
				heights[i] = disks[i][2];
			}
			int[] sequences = new int[len];
			for (int i = 0; i < len; i++)
			{
				sequences[i] = int.MinValue;
			}
			int maxHeight = int.MinValue;
			int maxHeightIdx = 0;
			for (int i = 1; i < len; i++)
			{
				int[] currentDisk = disks[i];
				for (int k = 0; k < i; k++)
				{
					int[] otherDisk = disks[k];
					if (otherDisk[2] < currentDisk[2] && otherDisk[1] < currentDisk[1]
						&& otherDisk[0] < currentDisk[0])
					{
						if (heights[k] + currentDisk[2] > heights[i])
						{
							heights[i] = heights[k] + currentDisk[2];
							sequences[i] = k;
						}
					}
					if (heights[i] >= maxHeight)
					{
						maxHeight = heights[i];
						maxHeightIdx = i;
					}
				}
			}


			return buildSequences(disks, sequences, maxHeightIdx);
		}

		private static List<int[]> buildSequences(List<int[]> disks, int[] sequences, int startIdx)
		{
			List<int[]> targetDisks = new List<int[]>();
			while (startIdx != int.MinValue)
			{
				int[] currentDisk = disks[startIdx];
				targetDisks.Insert(0, currentDisk);
				startIdx = sequences[startIdx];
			}
			return targetDisks;
		}
	}

}
