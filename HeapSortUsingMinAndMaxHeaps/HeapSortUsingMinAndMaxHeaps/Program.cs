using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSortUsingMinAndMaxHeaps
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = HeapSort(new int[] { 8, 5, 2, 9, 5, 6, 3 });
            Console.ReadLine();

        }

        public static int[] HeapSort(int[] array)
        {
            // Write your code here.
            //T.C is O(NLog(N)) and S.C is O(1)

            if (array.Length <= 1)
            {
                return array;
            }
            BuildMinHeap(array);
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Swap(0, i, array);
                siftDown(0, i - 1, array);
            }

            for (int i = 0; i < array.Length / 2; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }
            return array;
        }

        public static void BuildMinHeap(int[] array)
        {
            int firstParentIdx = (array.Length - 2) / 2;
            for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
            {
                siftDown(currentIdx, array.Length - 1, array);
            }
        }

        public static void siftDown(int currentIdx, int endIdx, int[] heap)
        {
            // Write your code here.
            //Get ChildNodes
            int childNode1_Idx = 2 * currentIdx + 1;
            while (childNode1_Idx <= endIdx)
            {
                int childNode2_Idx = 2 * currentIdx + 2;
                int indexToSwap;
                if (childNode2_Idx <= endIdx && heap[childNode2_Idx] < heap[childNode1_Idx])
                {
                    indexToSwap = childNode2_Idx;
                }
                else
                {
                    indexToSwap = childNode1_Idx;
                }

                if (heap[indexToSwap] < heap[currentIdx])
                {
                    Swap(indexToSwap, currentIdx, heap);
                    currentIdx = indexToSwap;
                    childNode1_Idx = 2 * currentIdx + 1;
                }
                else
                {
                    return;
                }
            }
        }

        public static void Swap(int i, int j, int[] heap)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

    }
}
