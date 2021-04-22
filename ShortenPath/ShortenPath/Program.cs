using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = getShortenPath(",Mahesh chand,bal,");
            Console.ReadLine();
        }

        private static string getShortenPath(string path)
        {
            bool startsWithPath = path[0] == '/';
            List<string> tokensList = path.Split(',').ToList();
            var val = string.Join("/", tokensList);
            return val;
        }
    }
}
