using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWordsInaString
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = ReverseWordsInString("AlgoExpert is the best!");
            Console.ReadLine();
        }

        public static string ReverseWordsInString(string str)
        {

            // Write your code here.
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            List<int[]> sb = new List<int[]>();
            int i = 0;
            int j = 0;
            while (i < str.Length)
            {
                if (str[i] == ' ')
                {
                    sb.Add(new int[] { j, i - j });
                    j = i + 1;
                }
                i++;
            }

            sb.Add(new int[] { j, i - j });

            return ReverseStringBuilder(sb, str);
        }


        private static string ReverseStringBuilder(List<int[]> sb, string str)
        {
            List<string> newSb = new List<string>();
            for (int i = sb.Count - 1; i >= 0; i--)
            {
                newSb.Add(str.Substring(sb[i][0], sb[i][1]));
                if (i != 0)
                {
                    newSb.Add(" ");
                }
            }

            string final = string.Join("", newSb);
            return final;
        }
 
    }
}
