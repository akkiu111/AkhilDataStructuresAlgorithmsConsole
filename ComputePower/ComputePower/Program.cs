using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputePower
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = MyPow(2.00000,
-2147483648);
            Console.ReadLine();
        }

        public static double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            long N = n;
            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }
            double ans = 1;
            while (N > 0)
            {

                if (N % 2 == 1)
                {
                    ans = ans * x;
                }
                x = x * x;
                N = N / 2;
            }

            return ans;
        }

    }
}
