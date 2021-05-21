using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfMaxPathTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<List<int>> { new List<int> { 1 }, new List<int> { 2, 1 }, new List<int> { 1, 2, 3 },
            new List<int> { 9, 5, 6, 7 }};
            int sum = maxSumFromAnyPath(input);
            Console.WriteLine(sum);    
            Console.ReadLine();

        }

        // Let's consider a triangle(right angled) of numbers in which a number appears in the first line, two numbers appear in the second line, three in the third line, etc. Develop a program which will compute the largest of the sums of numbers that appear on the paths, so that:
        // 1. On each path the next number is located on the row below, more precisely either directly below or below and one place to the right;// 2. The number of rows is strictly positive, but less than 100// 3. All numbers are positive integers between 0 and 99.

        // Input:// 1// 2 1// 1 2 3

        // Output: 5


        static int maxSumFromAnyPath(List<List<int>> input) 
        {
            int val = maxSumFromAnyPathHelper(input);
            List<int> paths = new List<int>();
            maxSumFromAnyPathHelperBruteForce(input, 0, 0, 0, 0, paths);
            return val;
        }

        static void maxSumFromAnyPathHelperBruteForce(List<List<int>> input, int row, int col, int level, int prefix, List<int> paths)
        {
            if(level == input.Count - 1)
            {
                prefix += input[row][col];
                paths.Add(prefix);
                return;
            }

            prefix += input[row][col];
            maxSumFromAnyPathHelperBruteForce(input, row + 1, col, level + 1, prefix, paths);
            maxSumFromAnyPathHelperBruteForce(input, row + 1, col + 1, level + 1, prefix, paths);
        }
        static int maxSumFromAnyPathHelper(List<List<int>> input)
        {
            int maxVal = int.MinValue;
            for (int i = 0; i < input.Count - 1; i++)
            {
                int prevBelow = i < input.Count - 1 ? input[i + 1][0] : 0;
 
                for (int j = 0; j < input[i].Count; j++)
                {
                    int currentVal = input[i][j];
                    int belowVal = input[i + 1][j];
                    int belowPlusRight = input[i + 1][j + 1];

                    input[i + 1][j] = Math.Max(belowVal, currentVal + prevBelow);
                    input[i + 1][j +1] = Math.Max(belowPlusRight, currentVal + belowPlusRight);
                    maxVal = Math.Max(maxVal, Math.Max(input[i + 1][j], input[i + 1][j + 1]));
                    prevBelow = belowPlusRight;
                }
            }

            return maxVal;
        }

    }
}
