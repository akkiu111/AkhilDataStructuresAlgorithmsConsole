using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsInAContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = numberOfItems("|**|*|*", new List<int> { 1, 1 }, new List<int> { 5, 6 });
            Console.ReadLine();
        }

        public static List<int> numberOfItems(string s, List<int> startIndices, List<int> endIndices)
        {
            //// WRITE YOUR BRILLIANT CODE HERE
            int n = s.Length;
            Dictionary<int, int> prefixSums = new Dictionary<int, int>();
            int curSum = 0;
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '|')
                {
                    prefixSums[i] = curSum;
                }
                else
                {
                    curSum++;
                }
            }
            int[] leftBounds = new int[n];
            int last = -1;
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '|')
                {
                    last = i;
                }
                leftBounds[i] = last;
            }
            int[] rightBounds = new int[n];
            last = -1;
            for (int i = n - 1; i >= 0; i--)
            {
                if (s[i] == '|')
                {
                    last = i;
                }
                rightBounds[i] = last;
            }
            List<int> res = new List<int>();
            for (int i = 0; i < startIndices.Count; i++)
            {
                int start = rightBounds[startIndices[i]];
                int end = leftBounds[endIndices[i]];
                if (start != -1 && end != -1 && start < end)
                {
                    res.Add(prefixSums[end] - prefixSums[start]);
                }
                else
                {
                    res.Add(0);
                }
            }
            return res;


            //    List<int> result = new List<int>();
            //    for (int i = 0; i < startIndices.Count; i++){
            //    int start = startIndices[i];
            //    int end = endIndices[1];
            //    int item = 0;
            //    while (start < end)
            //    {

            //        while (start < end && s[start] == '|')
            //        {
            //            start++;
            //        }
            //        while (start < end && s[end] == '|')
            //        {
            //            end--;
            //        }
            //        for (int j = start + 1; j < end; ++j)
            //        {
            //            if (s[j] == '*')
            //            {
            //                item++;
            //            }
            //        }
            //        break;
            //    }
            //    result.Add(item);
            //    //item = 0;
            //}

            //return result;
        }
    }
}
