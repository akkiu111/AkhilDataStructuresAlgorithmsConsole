using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupingAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = OptimalGroupAnagrams(new string[] { "bdddddddddd", "bbbbbbbbbbc" });
            var output1 = SubOptimalGroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });

            Console.ReadLine();
        }

        public static IList<IList<string>> OptimalGroupAnagrams(string[] strs)
        {

            Dictionary<string, IList<string>> anagrams = new Dictionary<string, IList<string>>();
            int[] count = new int[26];
            for (int i = 0; i < strs.Length; i++)
            {
                string actualString = strs[i];
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < 26; j++)
                {
                    count[j] = 0;
                }

                for(int k = 0; k < actualString.Length; k++)
                {
                    count[actualString[k] - 'a'] = count[actualString[k] - 'a'] + 1 ;
                }

                for(int d = 0; d < 26; d++)
                {
                    sb.Append(count[d]);
                    sb.Append("a");
                }

                var sbKey = sb.ToString();
               

                if (anagrams.ContainsKey(sbKey))
                {
                    anagrams[sbKey].Add(actualString);
                }
                else
                {
                    anagrams.Add(sbKey, new List<string> { actualString });
                }

            }
            return anagrams.Values.ToList();

        }

        public static IList<IList<string>> SubOptimalGroupAnagrams(string[] strs)
        {

            Dictionary<string, IList<string>> anagrams = new Dictionary<string, IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                string actualString = strs[i];
                var sortCharArray = actualString.ToCharArray();
                Array.Sort(sortCharArray);
                string sortedString = new string(sortCharArray);

                if (anagrams.ContainsKey(sortedString))
                {
                    anagrams[sortedString].Add(actualString);
                }
                else
                {
                    anagrams.Add(sortedString, new List<string> { actualString });
                }

            }
            return anagrams.Values.ToList();

        }
    }
}
