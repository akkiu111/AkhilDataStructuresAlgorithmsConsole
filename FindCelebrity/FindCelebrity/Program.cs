using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCelebrity
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] input = new int[,]{
                {0, 0, 1, 0 ,1},
                {0, 0, 1, 0 ,1},
                {0, 0, 0, 0 ,1},
                {0, 0, 1, 0 ,1},
                {0, 0, 0, 0 ,0}
            };

            var output = findCeleberityFromMatrixGraph(input);
            Console.Write(output);
            output = findCeleberityFromMatrixStack(input);
            Console.Write(output);
            output = findCeleberityFromMatrixOptimal(input);
            Console.Write(output);
            Console.ReadLine();
        }

        private static int findCeleberityFromMatrixStack(int[,] input)
        {
            Stack<int> stack = new Stack<int>();
            int n = input.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                stack.Push(i);
            }

            int count = 0;
            while (count < n - 1)
            {
                int first = stack.Peek();
                stack.Pop();
                int second = stack.Peek();
                stack.Pop();

                if (knows(input, first, second) == 1)
                {
                    stack.Push(second);
                }
                else
                {
                    stack.Push(first);
                }

                count++;
            }

            return stack.Count == 0 ? -1 : stack.Peek();
        }

        private static int findCeleberityFromMatrixOptimal(int[,] input)
        {
            int n = input.GetLength(0);
            int celebrity = 0;

            for (int i = 1; i < n; i++)
            {
                if (knows(input, celebrity, i) == 1)
                {
                    celebrity = i;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if ((i != celebrity && (knows(input, celebrity, i) == 1)) || !(knows(input, i, celebrity) == 1))
                {
                    return -1;
                }
            }

            return celebrity;
        }

        private static int findCeleberityFromMatrixGraph(int[,] input)
        {
            int[] incoming = new int[input.GetLength(0)];
            int[] outgoing = new int[input.GetLength(1)];


            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    int x = knows(input, i, j);
                    incoming[j] += x;
                    outgoing[i] += x;
                }
            }

            int n = input.GetLength(0);
            for (int i = 0; i < input.GetLength(0); i++)
            {
                if ((incoming[i] == n - 1) && (outgoing[i] == 0))
                {
                    return i;
                }
            }

            return -1;
        }

        private static int knows(int[,] matrix, int a, int b)
        {

            return matrix[a, b];
        }
    }
}
