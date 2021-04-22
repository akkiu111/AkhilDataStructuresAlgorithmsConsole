using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverSizesList
{
    class Program
    {
        static void Main(string[] args)
        {
           var output= RiverSizes(new int[,]
           {
             { 1, 1, 0 },
             { 1, 0, 1 },
             { 1, 1, 1 },
             { 1, 1, 0 },
             { 1, 0, 1 },
             { 0, 1, 0 },
             { 1, 0, 0 },
             { 1, 0, 0 },
             { 0, 0, 0 },
             { 1, 0, 0 },
             { 1, 0, 1 },
             { 1, 1, 1 }
           });
            Console.ReadLine();
        }

        public static int NumIslands(char[][] grid)
        {
            int output = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '0')
                    {
                        continue;
                    }

                    helper(grid, i, j);
                    output++;
                }
            }

            return output;
        }

        private static void helper(char[][] grid, int i, int j)
        {
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { i, j });
            while (queue.Count > 0)
            {
                int[] current = queue.Dequeue();
                i = current[0];
                j = current[1];
                if (grid[i][j] == '0')
                {
                    continue;
                }
                grid[i][j] = '0';
                List<int[]> neighbors = getNeighbors(grid, i, j);
                foreach (int[] neighbor in neighbors)
                {
                    queue.Enqueue(neighbor);
                }

            }

        }

        private static List<int[]> getNeighbors(char[][] grid, int i, int j)
        {
            List<int[]> neighbors = new List<int[]>();
            if (i > 0)
            {
                neighbors.Add(new int[] { i - 1, j });
            }
            if (j > 0)
            {
                neighbors.Add(new int[] { i, j - 1 });
            }
            if (i + 1 < grid.Length)
            {
                neighbors.Add(new int[] { i + 1, j });
            }
            if (j + 1 < grid[i].Length)
            {
                neighbors.Add(new int[] { i, j + 1 });
            }

            return neighbors;
        }

        //public static List<int> RiverSizes(int[,] matrix)
        //{
        //    // Write your code here.
        //    List<int> output = new List<int>();
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            if (matrix[i, j] == 0)
        //            {
        //                continue;
        //            }
        //            helper(matrix, i, j, output);
        //        }
        //    }
        //    return output;
        //}

        //private static void helper(int[,] matrix, int i, int j, List<int> output)
        //{
        //    int riverSize = 0;
        //    Queue<int[]> queue = new Queue<int[]>();
        //    queue.Enqueue(new int[] { i, j });
        //    while (queue.Count > 0)
        //    {
        //        int[] rowColInfo = queue.Dequeue();
        //        i = rowColInfo[0];
        //        j = rowColInfo[1];
        //        if(matrix[i, j] == 0){
        //            continue;
        //        }

        //        matrix[i, j] = 0;
        //        riverSize++;
        //        List<int[]> neighbors = getNeighbors(matrix, i, j);
        //        foreach (int[] neighbor in neighbors)
        //        {
        //            queue.Enqueue(neighbor);
        //        }
        //    }
        //    if (riverSize > 0)
        //    {
        //        output.Add(riverSize);
        //    }
        //}

        //private static List<int[]> getNeighbors(int[,] matrix, int i, int j)
        //{
        //    List<int[]> neighbors = new List<int[]>();
        //    if (i > 0 && matrix[i - 1, j] != 0)
        //    {
        //        neighbors.Add(new int[] { i - 1, j });
        //    }
        //    if (j > 0 && matrix[i, j - 1] != 0)
        //    {
        //        neighbors.Add(new int[] { i, j - 1 });
        //    }
        //    if (i + 1 < matrix.GetLength(0) && matrix[i + 1, j] != 0)
        //    {
        //        neighbors.Add(new int[] { i + 1, j });
        //    }
        //    if (j + 1 < matrix.GetLength(1) && matrix[i, j + 1] != 0)
        //    {
        //        neighbors.Add(new int[] { i, j + 1 });
        //    }

        //    return neighbors;
        //}

    }
}
