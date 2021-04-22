using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNextPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = NextPermutation(new int[] {  1, 5, 1 });
            Console.ReadLine();
        }

        public static int[] NextPermutation(int[] nums)
        {

            //Find the first decreasing sequence
            int i = nums.Length - 1;
            while (i > 0 && nums[i - 1] >= nums[i])
            {
                i--;
            }

            i--;
            //Swap the number before the strict decreasing sequence with the next largest number with in the strict 
            //decreasing sequence

            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (j > i && nums[i] >= nums[j])
                {
                    j--;
                }

                Swap(nums, i, j);
            }

            //Now Reverse the reeamining sequence after that number into the increasing sequence
            ReverseSequence(nums, i + 1);

            return nums;
        }

        private static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        private static void ReverseSequence(int[] nums, int i)
        {

            int j = nums.Length - 1;
            while (i < j)
            {
                Swap(nums, i, j);
                i++;
                j--;
            }
        }
    }
}
