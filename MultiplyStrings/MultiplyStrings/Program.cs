using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = Multiply("123", "456");
            Console.ReadLine();
        }
        public static string Multiply(string num1, string num2)
        {

            if(num1.Length == 0 || num2.Length == 0)
            {
                return "0";
            }

            if(num1.Length == 1 && num1[0] == '0' || num2.Length == 1 && num2[0] == '0')
            {
                return "0";
            }

            int i = num1.Length;
            int j = num2.Length;
            int[] nums = new int[i + j];
            for( i = num1.Length - 1; i >=0; i--)
            {
                int num1Digit = num1[i] - '0';
                int carry = 0;
                for (j = num2.Length - 1; j >= 0; j--)
                {
                    int num2Digit = num2[j] - '0';
                    int product = nums[i + j + 1] + carry + (num1Digit * num2Digit);
                    nums[i + j + 1] = product % 10;
                    carry = product / 10;
                }

                if(carry != 0)
                {
                    nums[i] = nums[i] + carry;
                }
            }

            int k = 0;
            while (k < nums.Length && nums[k] == 0)
            {
                k++;
            }

            StringBuilder sb = new StringBuilder();
            while(k < nums.Length)
            {
                sb.Append(nums[k]);
                k++;
            }

            return sb.ToString();
        }
    }
}
