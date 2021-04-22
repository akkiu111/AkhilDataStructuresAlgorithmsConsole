using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunsetViews
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = SunsetViews(new int[] { 3, 5, 4, 4, 3, 1, 3, 2 }, "WEST");
            Console.ReadLine();
        }

        public static List<int> SunsetViews(int[] buildings, string direction)
        {
			List<int> output = new List<int>();

			if (buildings.Length == 0)
			{
				return output;
			}
			Stack<int> stack = new Stack<int>();

			int idx = buildings.Length - 2;
			int next = 1;

			if (direction == "WEST")
			{
				idx = 1;
				next = -1;
			}

			output.Add(idx + next);
			stack.Push(buildings[idx + next]);

			while (idx >= 0 && idx < buildings.Length)
			{
				if (buildings[idx] > buildings[idx + next] && buildings[idx] > stack.Peek())
				{
					output.Add(idx);
					stack.Push(buildings[idx]);
				}

				idx = idx - next;
			}

			if (direction == "EAST")
			{
				output.Reverse();
			}

			return output;
		}

        /*public static  List<int> SunsetViews(int[] buildings, string direction)
		{
			// Write your code here.
			Stack<int> stack = new Stack<int>();
			List<int> output = new List<int>();
			int[] adjustedBuilding = new int[buildings.Length];
			for (int i = 0; i < buildings.Length; i++)
			{
				adjustedBuilding[i] = buildings[i];
			}

			if (direction == "WEST")
			{
				int i = 0;
				int j = adjustedBuilding.Length - 1;
				int half = adjustedBuilding.Length / 2;
				while (i < half)
				{
					Swap(adjustedBuilding, i, j);
					i++;
					j--;
				}
			}
			output.Insert(0, adjustedBuilding.Length - 1);
			stack.Push(adjustedBuilding[adjustedBuilding.Length - 1]);
			for (int i = adjustedBuilding.Length - 2; i >= 0; i++)
			{
				if (adjustedBuilding[i] > adjustedBuilding[i + 1] && adjustedBuilding[i] > stack.Peek())
				{
					output.Insert(0, i);
					stack.Push(adjustedBuilding[i]);
				}
			}

			return output;
		}

		private static void Swap(int[] adjustedBuilding, int i, int j)
		{
			int temp = adjustedBuilding[i];
			adjustedBuilding[i] = adjustedBuilding[j];
			adjustedBuilding[j] = temp;
		}
		*/
    }
}
