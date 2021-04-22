using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderscorifySubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var output =  "_test_this is a _testtest_ to see if _testestest_ it works" 
                == Underscorify("testthis is a testtest to see if testestest it works", "test");
            Console.ReadLine();
        }


        private static string Underscorify(string str, string subStr)
        {
            List<List<int>> locations = GetLocations(str, subStr);

            List<List<int>> newLocations = GetNewLocations(locations);

            return underscorifiedString(str, newLocations);
        }

        private static string underscorifiedString(string str, List<List<int>> newLocations)
        {
            int strIdx = 0;
            int locationsIdx = 0;
            int i = 0;
            var finalChars = new List<string>();
            while (strIdx < str.Length && locationsIdx < newLocations.Count)
            {
                if (strIdx == newLocations[locationsIdx][i])
                {
                    finalChars.Add("_");
                    if (i == 1)
                    {
                        locationsIdx++;
                    }

                    i = i == 0 ? 1 : 0;
                }

                finalChars.Add(str[strIdx].ToString());
                strIdx++;
            }


            if (locationsIdx < newLocations.Count)
            {
                finalChars.Add("_");
            }
            else if (strIdx < str.Length)
            {
                finalChars.Add(str.Substring(strIdx));
            }


            return string.Join("", finalChars);

            // var finalChars = new List<string>();
            //int i = 1;
            //while (i <= newLocations.Count)
            //{
            //    finalChars.Add("_");
            //    finalChars.Add(str.Substring(newLocations[i-1][0], newLocations[i - 1][1] - newLocations[i - 1][0]));
            //    finalChars.Add("_");
            //    if (i != newLocations.Count)
            //    {
            //        finalChars.Add(str.Substring(newLocations[i - 1][1], newLocations[i][0] - newLocations[i - 1][1]));
            //    }
            //    else
            //    {
            //        finalChars.Add(str.Substring(newLocations[newLocations.Count - 1][1], str.Length - newLocations[newLocations.Count - 1][1]));
            //    }
            //    i++;
            //}
            //if (newLocations[newLocations.Count - 1][0] == str.Length)
            //{
            //    finalChars.Add("_");
            //}
            // return string.Join("", finalChars);
        }

        private static List<List<int>> GetNewLocations(List<List<int>> locations)
        {
            List<List<int>> newLocations = new List<List<int>>();
            newLocations.Add(locations[0]);
            var previous = newLocations[0];
            for (int i = 1; i < locations.Count; i++)
            {
                var current = locations[i];
                if (current[0] <= previous[1])
                {
                    previous[1] = current[1];
                }
                else
                {
                    newLocations.Add(current);
                    previous = current;
                }
            }

            return newLocations;
        }

        private static List<List<int>> GetLocations(string str, string subStr)
        {
            int mp = 0;
            int sp = 0;
            int startIdx = 0;
            List<List<int>> locations = new List<List<int>>();
            
            //while (mp < str.Length)
            //{
            //    while (sp < subStr.Length)
            //    {
            //        if (str[mp] == subStr[sp])
            //        {
            //            mp++;
            //            sp++;
            //        }
            //        else
            //        {
            //            if (sp > 0)
            //            {
            //                mp--;
            //            }
            //            break;
            //        }
            //    }
            //    if (sp == subStr.Length)
            //    {
            //        locations.Add(new List<int> { mp - sp, mp });
            //        mp--;
            //    }
            //    else
            //    {
            //        mp++;
            //    }
            //    sp = 0;
            //}
            while (startIdx < str.Length)
            {
                int nextIdx = str.IndexOf(subStr, startIdx);
                if (nextIdx != -1)
                {
                    locations.Add(new List<int> { nextIdx, nextIdx + subStr.Length });
                    startIdx = nextIdx + 1;
                }
                else
                {
                    break;
                }
            }
            return locations;
        }
    }
}
