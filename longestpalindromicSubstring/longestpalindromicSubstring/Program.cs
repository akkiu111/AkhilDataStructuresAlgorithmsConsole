using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longestpalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = LongestPalindromeSubstring("noon");
			Console.ReadLine();
        }


		public static string LongestPalindromeSubstring(string str)
		{
			// Write your code here.
			// T.C is O(N^2) and S.C is O(N) where N is the length of string

			if (str == null || str.Length == 0)
			{
				return str;
			}

			if (str.Length == 1)
			{
				return str;
			}

			int maxLengthSubstring = 0;
			string maxSubstring = "";

			for (int i = 1; i < str.Length; i++)
			{
				for (int j = 0; j < i; j++)
				{
					string subString = str.Substring(j, i - j + 1);
					if (isPalindrome(subString))
					{
						if (subString.Length > maxLengthSubstring)
						{
							maxLengthSubstring = subString.Length;
							maxSubstring = subString;
						}
					}
				}
			}

			return maxSubstring;
		}

		private static bool isPalindrome(string str)
		{
			if (str.Length == 1)
			{
				return true;
			}
			int i = 0;
			int j = str.Length - 1;
			while (i <= j && str[i++] == str[j--]) { }
			return i > j && str[i] == str[j];
		}
	}
}
