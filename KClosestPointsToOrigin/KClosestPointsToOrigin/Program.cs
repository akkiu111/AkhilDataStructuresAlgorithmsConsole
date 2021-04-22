using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClosestPointsToOrigin
{
    class Program
    {
        static void Main(string[] args)
        {
            /* var output = KClosest(new int[][] { new int[] {6, 10},
                 new int[] {-3,3}, new int[] { -2, 5}, new int[] { 0, 2}
             }, 3);
            */
            var output2 = KClosest(new int[][] { new int[] {1, 3},
                new int[] {-2,2}
            }, 1);
            var output3 = KClosest(new int[][] { new int[] {3, 3},
                new int[] {5, -1}, new int[] {-2, 4},

            }, 2);
            var output4 = KClosest(new int[][] { new int[] {0, 1},
                new int[] {1, 0}

            }, 2);
            Console.ReadLine();
        }

        public static int[][] KClosest(int[][] points, int K)
        {
            int indexValue = quickSelect(0, points.Length - 1, points, K - 1);
            List<int[]> output = new List<int[]>();

            for (int i = 0; i < K; i++)
            {
                output.Add(points[i]);
            }

            return output.ToArray();
        }

        public static double getDistanceFromOrigin(int[][] points, int i)
        {
            double distance = (points[i][0] * points[i][0]) + (points[i][1] * points[i][1]);
            return Math.Sqrt(distance);

        }


        public static int quickSelect(int start, int end, int[][] points, int position)
        {
            while (true)
            {
                if (start > end)
                {
                    return -1;
                }

                int pivot = start;
                int left = start + 1;
                int right = end;

                while (right >= left)
                {

                    double pivotDistance = getDistanceFromOrigin(points, pivot);
                    double leftIdxValDistance = getDistanceFromOrigin(points, left);
                    double rightIdxValDistace = getDistanceFromOrigin(points, right);

                    if (leftIdxValDistance > pivotDistance && rightIdxValDistace < pivotDistance)
                    {
                        Swap(points, left, right);
                        continue;
                    }
                    if (leftIdxValDistance <= pivotDistance)
                    {
                        left++;
                    }
                    if (rightIdxValDistace >= pivotDistance)
                    {
                        right--;
                    }
                }
                Swap(points, right, pivot);
                if (right == position)
                {
                    return right;
                }

                if (right < position)
                {
                    start = right + 1;
                }
                else
                {
                    end = right - 1;
                }
            }
        }

        public static void Swap(int[][] points, int i, int j)
        {
            int x = points[i][0];
            int y = points[i][1];
            points[i][0] = points[j][0];
            points[i][1] = points[j][1];
            points[j][0] = x;
            points[j][1] = y;
        }
        /*
        public static int[][] KClosest(int[][] points, int K)
        {
            Dictionary<double, List<int>> dictionary = new Dictionary<double, List<int>>();
            List<double> srqtVals = new List<double>();
            for (int i = 0; i < K; i++)
            {
                double val = getSqRtVal(points, i);
                srqtVals.Add(val);
                updateDictionary(dictionary, i, val);
            }

            MaxHeap maxHeap = new MaxHeap(srqtVals);


            List<int[]> output = new List<int[]>();
            for (int i = K; i < points.Length; i++)
            {
                double maxVal = maxHeap.peek();

                double val = getSqRtVal(points, i);

                if (val < maxVal)
                {
                    maxHeap.replace(val);
                    updateDictionary(dictionary, i, val);
                }
            }

            foreach (var vals in maxHeap.heap)
            {
                foreach (var index in dictionary[vals])
                {
                    if (output.Count == K)
                    {
                        break;
                    }
                    output.Add(points[index]);
                }
            }

            return output.ToArray();
        }


        public static double getSqRtVal(int[][] points, int i)
        {
            double distance = (points[i][0] * points[i][0]) + (points[i][1] * points[i][1]);
            return Math.Sqrt(distance);

        }

        public static void updateDictionary(Dictionary<double, List<int>> dictionary, int i, double val)
        {
            if (!dictionary.ContainsKey(val))
            {
                dictionary.Add(val, new List<int>());
            }
            dictionary[val].Add(i);
        }


        public class MaxHeap
        {

            public List<double> heap = new List<double>();

         
            public MaxHeap(List<double> array)
            {
                heap = buildMaxHeap(array);
            }
            public List<double> buildMaxHeap(List<double> array)
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

            public void siftDown(int startIdx, int endIdx, List<double> array)
            {
                int childOneIdx = (2 * startIdx) + 1;
                while (childOneIdx <= endIdx)
                {
                    int childTwoIdx = (2 * startIdx) + 2;
                    int idxToSwap;
                    if (childTwoIdx <= endIdx && array[childTwoIdx] > array[childOneIdx])
                    {
                        idxToSwap = childTwoIdx;
                    }
                    else
                    {
                        idxToSwap = childOneIdx;
                    }

                    if (array[idxToSwap] > array[startIdx])
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
                while (currentIdx > 0 && heap[currentIdx] > heap[parentIdx])
                {
                    Swap(parentIdx, currentIdx, heap);
                    currentIdx = parentIdx;
                    parentIdx = (currentIdx - 1) / 2;
                }
            }

            public void insert(double val)
            {
                heap.Add(val);
                if (heap.Count > 1)
                {
                    siftUp(heap.Count - 1);
                }
            }

            public double delete()
            {
                if (heap.Count == 0)
                {
                    return -1;
                }
                double valToRemove = heap[0];
                Swap(0, heap.Count - 1, heap);
                heap.RemoveAt(heap.Count - 1);
                siftDown(0, heap.Count - 1, heap);
                return valToRemove;
            }

            public void replace(double val)
            {
                heap[0] = val;
                siftDown(0, heap.Count - 1, heap);
            }

            public double peek()
            {
                return heap[0];
            }

            public void Swap(int i, int j, List<double> array)
            {
                double temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        */
    }
}
