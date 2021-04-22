using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideTwoIntegersWithoutArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = Divide(29, 7);
            Console.ReadLine();
        }
        public static int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }
            if (dividend == int.MinValue && divisor == 1)
            {
                return int.MinValue;
            }

            bool negative = (dividend < 0) ^ (divisor < 0);
            dividend = dividend < 0 ? dividend : -dividend;
            divisor = divisor < 0 ? divisor : -divisor;

            int quotient = 0;
            int count = 1;
            int accum = divisor;
            while (accum >= int.MinValue >> 1
                      && dividend <= accum << 1)
            {
                count = count << 1;
                accum = accum << 1;
            }
            while (dividend <= divisor)
            {
                if (dividend <= accum)
                {
                    dividend = dividend - accum;
                    quotient = quotient + count;
                }
                accum = accum >> 1;
                count = count >> 1;
            }

            return negative ? -quotient : quotient;

        }
    }
}
