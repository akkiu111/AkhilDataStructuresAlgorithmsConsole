using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLengthEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "AAAAAAAAAAAAABBCCCCDD";
            var expected = "9A4A2B4C2D";
            var actual = RunLengthEncoding(input);
            var output = expected.Equals(actual);
            Console.ReadLine();
        }
        public static string RunLengthEncoding(string str)
        {
            int count = 1;
            var output = new StringBuilder();
            for (int i = 1; i < str.Length; i++)
            {
                var cur = str[i];
                var prev = str[i - 1];
                if (cur != prev || count == 9)
                {
                    output.Append(count.ToString());
                    output.Append(prev);
                    count = 0;
                }
                count++;
            }
            output.Append(count.ToString());
            output.Append(str[str.Length - 1]);
            return output.ToString();

        }

    }
}
