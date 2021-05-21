using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangularAreaHistogram
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = getMaxAreaFromHistogram(new int[] { 6, 1, 4, 3, 4, 2 });
            Console.ReadLine();
        }

        static int getMaxAreaFromHistogram(int[] heights)
        {
            int maxArea = int.MinValue;
            Stack<int> indexStack = new Stack<int>();
            int i = 0;
            while(i < heights.Length)
            {
                if(indexStack.Count == 0 || heights[i] >= heights[indexStack.Peek()])
                {
                    indexStack.Push(i++);
                }

                else
                {
                    maxArea = getMaxArea(heights, maxArea, indexStack, i);
                }
            }

            while(indexStack.Count != 0)
            {
                maxArea = getMaxArea(heights, maxArea, indexStack, i);
            }

            return maxArea;
        }

        private static int getMaxArea(int[] heights, int maxArea, Stack<int> indexStack, int i)
        {
            int poppedIndex = indexStack.Pop();
            if (indexStack.Count == 0)
            {
                maxArea = Math.Max(maxArea, heights[poppedIndex] * i);
            }
            else
            {
                maxArea = Math.Max(maxArea, (heights[poppedIndex] * (i - indexStack.Peek() - 1)));
            }

            return maxArea;
        }
    }
}
