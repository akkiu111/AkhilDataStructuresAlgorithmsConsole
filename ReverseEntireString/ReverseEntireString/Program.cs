using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseEntireString
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = ReverseTheString("Let's take LeetCode contest");
            Console.ReadLine();
        }

        private static string ReverseTheString(string str)
        {
            int i = str.Length - 1;
            StringBuilder sb = new StringBuilder();
            while (i >= 0)
            {
                sb.Append(str[i]);
                i--;
            }

            return sb.ToString();
        }
    }
}
