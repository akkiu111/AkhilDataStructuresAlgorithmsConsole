using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSetOrSubsets
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = Subsets(new int[] { 1, 2, 3 });
            Console.ReadLine();
        }
        public static IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            result.Add(new List<int>());
            for (int i = 0; i < nums.Length; i++)
            {
                int len = result.Count;
                for (int j = 0; j < len; j++)
                {
                    IList<int> sub = new List<int>(result[j]);
                    sub.Add(nums[i]);
                    result.Add(sub);
                }
            }

            return result;

        }

        /*   public IList<IList<int>> Subsets(int[] nums) {
              IList<IList<int>> result = new List<IList<int>>();
            //  result.Add(new List<int>{});
              UpdateSubsets(result, new List<int>(), nums, 0);
              return result;
          }

         public void UpdateSubsets( IList<IList<int>> result, IList<int> sub, int[] nums, int i){

              result.Add(new List<int>(sub));

              for(int j = i; j < nums.Length; j++){
                  sub.Add(nums[j]);
                  UpdateSubsets(result, sub, nums, j+1);
                  sub.RemoveAt(sub.Count - 1);
              }
          }
          */
    }
}
