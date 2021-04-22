using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringsGreaterthanGivenValue
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = solveSubstring(8, "10");
            Console.ReadLine();
        }

        private static int solveSubstring(int k, string str)
        {
            int ways = 0;
            ways = recursionSolving(0, str, k, ways, new StringBuilder());
            return ways;
        }

        private static int recursionSolving(int index, string str, int k, int ways, StringBuilder sb)
        {
            if(index  == str.Length)
            {
                return ways;
            }
           
            for (int i = index; i < str.Length; i++)
            {
                sb.Append(str[i]);
                if (Convert.ToInt32(sb.ToString()) > k)
                {
                    ways += 1;
                }

                ways = recursionSolving(i + 1, str, k, ways, sb);
                sb = new StringBuilder();

            }
            return ways;
        }
    }
}
