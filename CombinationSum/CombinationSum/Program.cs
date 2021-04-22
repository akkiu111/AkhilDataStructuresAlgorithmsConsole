using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CombinationSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = ComboSum(new List<int> { 2, 3, 5 }, 8);
            Console.ReadLine();
        }


        public static List<List<int>> ComboSum(List<int> candidates, int target)
        {
            List<List<int>> results = new List<List<int>>();
            List<int> combination = new List<int>();
            Array.Sort(candidates.ToArray());
            FindAllComboSum(results, combination, candidates, target, 0);
            return results;

        }

        private static void FindAllComboSum(List<List<int>> results, List<int> combination, List<int> candidates, int target, int startIndex)
        {

            if(target == 0)
            {
                results.Add(new List<int>(combination));
                return;
            }

            for(int i = startIndex; i < candidates.Count; i++)
            {
                if(candidates[i] > target)
                {
                    break;
                }

                combination.Add(candidates[i]);
                FindAllComboSum(results, combination, candidates, target - candidates[i], i);
                combination.RemoveAt(combination.Count - 1);
            }
        }
    }
}
