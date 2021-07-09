using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 3, 9, 8, 2, 14, 1, 7 };
            MergeSorting(input);
            Console.ReadLine();
        }

        private static void MergeSorting(int[] input)
        {
            int start = 0;
            int end = input.Length - 1;
            MergeSorting(input, start, end);
        }

        private static void MergeSorting(int[] input, int start, int end)
        {
           if(start >= end)
            {
                return;
            }
            int mid = start + ((end - start) / 2);
            MergeSorting(input, start, mid);
            MergeSorting(input, mid + 1, end);
            Merge(input, start, mid, end);
        }

        private static void Merge(int[] input, int start, int mid, int end)
        {
            int i = start;
            int j = mid + 1;
            int k = start;
            int[] temp = new int[input.Length];
            while(i <= mid && j <= end)
            {
                if(input[i] > input[j])
                {
                    temp[k] = input[j];
                    j++;
                }
                else if(input[i] <= input[j])
                {
                    temp[k] = input[i];
                    i++;
                }
                k++;
            }

            if(i > mid)
            {
                while (j <= end)
                {
                    temp[k] = input[j];
                    j++;
                    k++;
                }
            }
            else if( j > end)
            {
                while (i <= mid)
                {
                    temp[k] = input[i];
                    i++;
                    k++;
                }
            }

            for(k = start; k <= end; k++)
            {
                input[k] = temp[k];
            }
        }
    }
}
