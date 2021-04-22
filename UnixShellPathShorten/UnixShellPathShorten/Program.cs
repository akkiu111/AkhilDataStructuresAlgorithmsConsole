using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnixShellPathShorten
{
    class Program
    {
        static void Main(string[] args)
        {
			//var expected = "/foo/bar/baz";
			var output = ShortenPath("/foo/../test/../test/../foo//bar/./baz");
			Console.Read();
		}

		public static string ShortenPath(string path)
		{
			// Write your code here;
			// T.C and S.C is O(N) where N is the length of the input string
			bool startsWithPath = path[0] == '/';
			List<string> tokensList = path.Split('/').ToList();
			List<string> filteredTokens = tokensList.FindAll(token => isImportantToken(token));
			Stack<string> stack = new Stack<string>();
			if (startsWithPath)
			{
				stack.Push("");
			}

			foreach (string token in filteredTokens)
			{
				if (token == "..")
				{
					if (stack.Count == 0 || stack.Peek() == "..")
					{
						stack.Push(token);
					}
					else if (stack.Peek() != "")
					{
						stack.Pop();
					}
				}
				else
				{
					stack.Push(token);
				}
			}

			if (stack.Count == 1 && stack.Peek() == "")
			{
				return "/";
			}

			var arr = stack.ToArray();
			Array.Reverse(arr);
			return string.Join("/", arr);
		}

		private static bool isImportantToken(string token)
		{
			return token.Length > 0 && token != ".";
		}
	}
}
