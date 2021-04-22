using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterfallStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] array = new double[][] {
            new double[] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},
            new double[] {1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},
            new double[] {0.0, 0.0, 1.0, 1.0, 1.0, 0.0, 0.0},
            new double[] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},
            new double[] {1.0, 1.0, 1.0, 0.0, 0.0, 1.0, 0.0},
            new double[] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0},
            new double[] {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},
        };
            var source = 3;
            //double[] expected = { 0.0, 0.0, 0.0, 25.0, 25.0, 0.0, 0.0 };
            var output = WaterfallStreams(array, source);
            Console.ReadLine();
        }
		public static double[] WaterfallStreams(double[][] array, int source)
		{
			// Write your code here.
			var rowAbove = array[0];
			rowAbove[source] = -1;

			for (int i = 1; i < array.Length; i++)
			{
				var current = array[i];
				for (int j = 0; j < current.Length; j++)
				{
					int left = j;
					int right = j;
					bool hasWaterAbove = rowAbove[j] < 0;
					if (!hasWaterAbove)
					{
						continue;
					}
					bool hasBlock = current[j] == 1;

					if (!hasBlock)
					{
						current[j] = current[j] + rowAbove[j];
						continue;
					}

					double splitWater = ((rowAbove[j]) / 2);

					while (left - 1 >= 0)
					{
						left--;
						if (rowAbove[left] == 1.0)
						{
							break;
						}

						if (current[left] != 1)
						{

							current[left] = current[left] + splitWater;

							break;
						}
					}

					while (right + 1 < rowAbove.Length)
					{
						right++;
						if (rowAbove[right] == 1.0)
						{
							break;
						}
						if (current[right] != 1.0)
						{
							current[right] = current[right] + splitWater;

							break;
						}

					}
				}
				rowAbove = current;
			}

			for (int i = 0; i < rowAbove.Length; i++)
			{
				if (rowAbove[i] != 0)
				{
					rowAbove[i] = (rowAbove[i]) * (-100);
				}
			}

			return rowAbove;
		}
	}
}
