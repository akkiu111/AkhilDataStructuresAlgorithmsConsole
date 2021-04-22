using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueRemovalsWithConditions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call findPositions() with test cases here
            int[] output = findPositions(new int[] { 1, 2, 2, 3, 4, 5 }, 5);
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }
        }

        private static int[] findPositions(int[] arr, int x)
        {
            // Write your code here
            Queue<Node> queue1 = new Queue<Node>();
            Queue<Node> queue2 = new Queue<Node>();

            for (int i = 0; i < arr.Length; i++)
            {
                queue1.Enqueue(new Node(i + 1, arr[i]));
            }

            int count = x;

            List<int> final = new List<int>();
            while (x > 0 && queue1.Count > 0)
            {
                int maxVal = int.MinValue;
                int maxValIdx = -1;       
                for (int i = 0; i < count; i++)
                {
                    Node poppedVal = queue1.Dequeue();
                    if(poppedVal.val > maxVal)
                    {
                        maxVal = poppedVal.val;
                        maxValIdx = poppedVal.idx;
                    }
          
                    queue2.Enqueue(poppedVal);
                    if (queue1.Count == 0)
                    {
                        break;
                    }
                }


                while (queue2.Count > 0)
                {
                    Node poppedVal2 = queue2.Dequeue();
                    if (poppedVal2.val > 0)
                    {
                        poppedVal2.val = poppedVal2.val - 1;
                    }
                    if (poppedVal2.idx == maxValIdx && maxValIdx != -1)
                    {
                        final.Add(maxValIdx);
                        maxValIdx = -1;
                    }
                    else
                    {
                        queue1.Enqueue(poppedVal2);
                    }
                }

                x--;
            }
            return final.ToArray();
        }


        public class Node
        {
            public int idx;
            public int val;
            public Node(int idx, int val)
            {
                this.idx = idx;
                this.val = val;
            }
        }
    }
}
