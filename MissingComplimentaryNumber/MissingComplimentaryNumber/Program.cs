using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingComplimentaryNumber
{
    class Program
    {
        static void Main(string[] args)
        {
           // int a;
            fa(10);
            Console.ReadLine();
        }

        private static void fa(int num)
        {
            if(num == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine("a");
                fa(--num);
            }        
        }
    }
}
