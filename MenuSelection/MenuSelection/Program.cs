using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSelection
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = MenuSelect(10);
            Console.ReadLine();
        }

        private static int MenuSelect(int p)
        {
            int n = 2048, q = 0;

            while (p != 0)
            {

                q += p / n;
                p = p % n;
                n /= 2;
            }

            return q;
        }
    }
}
