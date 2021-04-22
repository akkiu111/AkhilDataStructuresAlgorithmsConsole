using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsValidPalindromeWithOneDeletion
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = ValidPalindrome("deeee");
            Console.ReadLine();
        }

        public static bool ValidPalindrome(string s)
        {
            if (s.Length == 0 || s.Length == 1)
            {
                return true;
            }
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return isRemainingPalindrome(s, left + 1, right) || isRemainingPalindrome(s, left, right - 1);
                }
                left++;
                right--;
            }

            return true;
        }

        public static bool isRemainingPalindrome(string s, int i, int j)
        {
            while (i < j)
            {
                if (s[i] != s[j])
                {
                    return false;
                }
                i++;
                j--;
            }

            return true;
        }
    }
}
