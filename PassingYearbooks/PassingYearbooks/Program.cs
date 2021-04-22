using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingYearbooks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call findSignatureCounts() with test cases here
            int[] output = findSignatureCounts(new int[] { 2, 1 }); // 2,2
            foreach (int val in output)
            {
                Console.WriteLine(val);
            }
            Console.ReadLine();
        }
     
        private static int[] findSignatureCounts(int[] arr)
        {
            // Write your code here
            arr.ToList();
            int[] output = new int[arr.Length];
            Dictionary<int, int> map = new Dictionary<int, int>();
            List<StudentBookInfo> sbi = new List<StudentBookInfo>();
            for (int i = 0; i < arr.Length; i++)
            {
                sbi.Add(new StudentBookInfo(i+1, i+1));
                output[i] = 1;
                map.Add(i + 1, arr[i]);
            }
           
            while(sbi[0].book != 1)
            {
                
            }
           
            HashSet<int> visited = new HashSet<int>();
            foreach (int k in map.Keys)
            {
                if (!visited.Contains(k))
                {
                    HashSet<int> round = new HashSet<int>();
                    while (!visited.Contains(k))
                    {
                        round.Add(k);
                        visited.Add(k);
                        //k = map[k];
                        //map[k] = 0;
                    }
                    foreach (int i in round)
                    {
                        output[i - 1] = round.Count;
                    }
                }
            }
            return output;
        }

        public class StudentBookInfo
        {
            public int currentStudent;
            public int book;

            public StudentBookInfo(int currentStudent, int book)
            {
                this.currentStudent = currentStudent;
                this.book = book;
            }
        }
    }
}
