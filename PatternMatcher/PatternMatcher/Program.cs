using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = patternMatch("gogopowerrangergogopowerranger", "xxyxxy");
            Console.ReadLine();
        }
        private static List<string> patternMatch(string str, string pattern)
        {
            char[] newPattern = getNewPattern(pattern);
            bool didSwitch = pattern[0] != newPattern[0];
            Dictionary<char, int> counts = new Dictionary<char, int>();
            counts['x'] = 0;
            counts['y'] = 0;
            int firstIndexOfY = getCountsAndFirstYPosition(newPattern, counts);
            if (counts['y'] != 0)
            {
                for (int lengthOfX = 1; lengthOfX < pattern.Length; lengthOfX++)
                {
                    double lengthOfY = ((double)str.Length - ((double)counts['x'] * (double)lengthOfX)) / (double)counts['y'];
                    if (lengthOfY <= 0 || lengthOfY % 1 != 0)
                    {
                        continue;
                    }

                    string x = str.Substring(0, lengthOfX);
                    int yIndex = lengthOfX * firstIndexOfY;
                    string y = str.Substring(yIndex, (int)lengthOfY);
                    string newStr = buildPotentialMatch(newPattern, x, y);
                    if (newStr == str)
                    {
                        return didSwitch ? new List<string> { y, x } : new List<string> { x, y };
                    }

                }
            }
            else
            {
                double lengthOfX = str.Length / counts['x'];
                if (lengthOfX % 1 == 0)
                {
                    string x = str.Substring(0, (int)lengthOfX);
                    string newStr = buildPotentialMatch(newPattern, x, "");
                    if (newStr == str)
                    {
                        return didSwitch ? new List<string> { "", x } : new List<string> { x, "" };
                    }
                }
                
            }

            return new List<string>();
        }

        private static char[] getNewPattern(string pattern)
        {
            char[] newPattern = pattern.ToCharArray();
            if(newPattern[0] == 'x')
            {
                return newPattern;
            }
            for (int i = 0; i < pattern.Length; i++)
            {
                if (newPattern[i] == 'x')
                {
                    newPattern[i] = 'y';
                }
                else
                {
                    newPattern[i] = 'x';
                }
            }

            return newPattern;
        }

        private static string buildPotentialMatch(char[] pattern, string x, string y)
        {
            StringBuilder newStr = new StringBuilder();
            foreach (char c in pattern)
            {
                if (c == 'x')
                {
                    newStr.Append(x);
                }
                else
                {
                    newStr.Append(y);
                }
            }

            return newStr.ToString();
        }

        private static int getCountsAndFirstYPosition(char[] pattern, Dictionary<char, int> counts)
        {
            int firstYPosition = -1;
            for (int i = 0; i < pattern.Length; i++)
            {
                char c = pattern[i];
                counts[c] = counts[c] + 1;
                if(c == 'y' && firstYPosition == -1)
                {
                    firstYPosition = i;
                }
            }

            return firstYPosition;
        }
    }

}
