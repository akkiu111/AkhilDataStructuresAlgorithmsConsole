using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSubsequenceDotProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayOne = new int[] { 4, 7, 9, -6, 6 };
            var arrayTwo = new int[] { 5, 1, -1, -3, -2, -10 };

            var output = 105 == maxSubseqeunceDotProductSum(arrayOne, arrayTwo);

            Console.ReadLine();
        }


        private static int maxSubseqeunceDotProductSum(int[] arrayOne, int[] arrayTwo)
        {
            var finalArray = getFinalArray(arrayOne, arrayTwo);
            for (int i = 1; i < finalArray.GetLength(0); i++)
            {
                for (int j = 1; j < finalArray.GetLength(1); j++)
                {
                    int current = arrayOne[i - 1] * arrayTwo[j - 1];
                    finalArray[i, j] = new int[] { current, handleOverFlow(finalArray[i - 1, j - 1], current), finalArray[i - 1, j], finalArray[i - 1, j - 1], finalArray[i, j - 1] }.Max();
                }
            }
            return finalArray[finalArray.GetLength(0) - 1, finalArray.GetLength(1) - 1];
        }

        private static int[,] getFinalArray(int[] arrayOne, int[] arrayTwo)
        {
            var finalArray = new int[arrayOne.Length + 1, arrayTwo.Length + 1];
            for(int i = 0; i < finalArray.GetLength(0); i++)
            {
                for(int j = 0; j < finalArray.GetLength(1); j++)
                {
                    finalArray[i, j] = int.MinValue;
                }
            }

            return finalArray;
        }
        private static int handleOverFlow(int number, int toAdd)
        {
            if(toAdd > 0)
            {
                return number + toAdd;
            }

            var willOverFlow = toAdd < 0 && number + toAdd > number;

            if (willOverFlow)
            {
                return number;
            }
            return number + toAdd ;
        }
    }
}
