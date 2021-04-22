using System;

namespace SortedRotatedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int output = SortedRotatedArraySearch(new int[] { 5, 6, 7, 8, 9, 10, 1, 2, 3 }, 3);
            Console.ReadLine();
        }

        private static int SortedRotatedArraySearch(int[] array, int key)
        {

            int start = 0;
            int end = array.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (array[mid] == key)
                {
                    return mid;
                }

                if (key < array[mid])
                {
                    if (key >= array[start])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }

                }
                else
                {
                    if (key <= array[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }
            return -1;
        }
    }
}