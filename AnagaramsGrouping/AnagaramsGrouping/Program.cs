using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagaramsGrouping
{
    class Program
    {
        static void Main(string[] args)
        {
			List<string> words = new List<string>(){
			"yo", "act", "flop", "tac", "foo", "cat", "oy", "olfp"
		};
			var output = groupAnagrams(words);
			Console.ReadLine();
		}

		public static List<List<string>> groupAnagrams(List<string> words)
		{
			// Write your code here.
			Dictionary<string, List<string>> cache = new Dictionary<string, List<string>>();
			foreach (string word in words)
			{
				char[] wordChars = word.ToCharArray();
				Array.Sort(wordChars);
				string sortedWord = new String(wordChars);
				if (!cache.ContainsKey(sortedWord))
				{
					cache.Add(sortedWord, new List<string>());
				}
				cache[sortedWord].Add(word);
			}

			List<List<string>> output = new List<List<string>>();
			foreach (string key in cache.Keys)
			{
				List<string> pair = new List<string>();
				foreach (string val in cache[key])
				{
					pair.Add(val);
				}
				output.Add(pair);
			}

			return output;
		}
	}
}
