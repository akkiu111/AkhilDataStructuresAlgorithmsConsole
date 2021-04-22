using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationsWithNoDuplicatePerms
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = PermuteUnique(new int[] { 1, 2, 1 });
            Console.ReadLine();
        }

        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            permutations(0, result, nums);
            return result;
        }

        public static void permutations(int i, IList<IList<int>> result, int[] nums)
        {
            if (i >= nums.Length - 1)
            {
                result.Add(new List<int>(nums));
                return;
            }
            HashSet<int> visited = new HashSet<int>();
            for (int j = i; j < nums.Length; j++)
            {
                if (visited.Contains(nums[j]))
                {
                    continue;
                }
                Swap(nums, i, j);
                permutations(i + 1, result, nums);
                Swap(nums, i, j);
                visited.Add(nums[j]);

            }
        }

        public static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
