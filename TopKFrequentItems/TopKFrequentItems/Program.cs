using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopKFrequentItems
{
    class Program
    {
        static void Main(string[] args)
        {
            // expected {1, 2}
            var output = TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3 }, 2);
            Console.ReadLine();
        }
        public class Node
        {
            public int number;
            public int frequency;

            public Node(int number, int frequency)
            {
                this.number = number;
                this.frequency = frequency;
            }
        }

        public static int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, Node> cache = new Dictionary<int, Node>();
            for (int i = 0; i < nums.Length; i++)
            {
                int number = nums[i];
                if (!cache.ContainsKey(number))
                {
                    cache.Add(number, new Node(number, 0));
                }
                cache[number].frequency = cache[number].frequency + 1;
            }

            Minheap minHeap = new Minheap();
            List<Node> nodesList = cache.Values.ToList();
            for(int i = 0; i < k; i++)
            {
                minHeap.insert(nodesList[i]);
            }

            for(int i = k; i < nodesList.Count; i++)
            {
                if(nodesList[i].frequency > minHeap.peek())
                {
                    minHeap.replace(nodesList[i]);
                }
            }


            int[] top = new int[k];
            int j = 0;
            while (j < k)
            {
                top[j] = minHeap.delete();
                j++;
            }

            return top;
        }

        public class Minheap
        {

            public List<Node> heap = new List<Node>();

           /* public Minheap(List<Node> array)
            {
                heap = buildMinHeap(array);
            }
           */

            public List<Node> buildMinHeap(List<Node> array)
            {
                if (array.Count <= 1)
                {
                    return array;
                }
                int firstParentIdx = (array.Count - 2) / 2;
                for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
                {
                    siftDown(currentIdx, array.Count - 1, array);
                }

                return array;
            }

            public void siftDown(int startIdx, int endIdx, List<Node> array)
            {
                int childOneIdx = (2 * startIdx) + 1;
                while (childOneIdx <= endIdx)
                {
                    int childTwoIdx = (2 * startIdx) + 2;
                    int idxToSwap;
                    if (childTwoIdx <= endIdx && array[childTwoIdx].frequency < array[childOneIdx].frequency)
                    {
                        idxToSwap = childTwoIdx;
                    }
                    else
                    {
                        idxToSwap = childOneIdx;
                    }

                    if (array[idxToSwap].frequency < array[startIdx].frequency)
                    {
                        Swap(idxToSwap, startIdx, array);
                        startIdx = idxToSwap;
                        childOneIdx = (2 * startIdx) + 1;
                    }
                    else
                    {
                        return;
                    }

                }
            }

            public void siftUp(int currentIdx)
            {
                int parentIdx = (currentIdx - 1) / 2;
                while (currentIdx > 0 && heap[currentIdx].frequency < heap[parentIdx].frequency)
                {
                    Swap(parentIdx, currentIdx, heap);
                    currentIdx = parentIdx;
                    parentIdx = (currentIdx - 1) / 2;
                }
            }

            public void insert(Node val)
            {
                heap.Add(val);
                if (heap.Count > 1)
                {
                    siftUp(heap.Count - 1);
                }
            }

            public int delete()
            {
                if (heap.Count == 0)
                {
                    return -1;
                }
                Node valToRemove = heap[0];
                Swap(0, heap.Count - 1, heap);
                heap.RemoveAt(heap.Count - 1);
                siftDown(0, heap.Count - 1, heap);
                return valToRemove.number;
            }

            public void replace(Node val)
            {
                heap[0] = val;
                siftDown(0, heap.Count - 1, heap);
            }

            public int peek()
            {
                return heap[0].frequency;
            }

            public void Swap(int i, int j, List<Node> array)
            {
                Node temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
