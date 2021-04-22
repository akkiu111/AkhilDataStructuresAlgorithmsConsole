using System;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var output = factorial(30, 7);
            Console.ReadLine();
        }

        private static long factorial(int n, int k)
        {
            if (n != 0)
            {
                n = n - 1;
            }
            k = k - 1;
            if (k > n / 2)
            {
                k = n - k;
            }
            long j = 0;
            long ans = 1;
            while (j < k)
            {

                ans = ans * (n - j);
                ans = ans / (j + 1);
                j++;
            }

            return ans;
        }
    }
}
