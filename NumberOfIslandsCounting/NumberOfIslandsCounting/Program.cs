using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfIslandsCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] bfsInput = new char[][] {
           new char[]{'1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '0', '1', '1'},
new char[]{'0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '0'},
new char[]{'1', '0', '1', '1', '1', '0', '0', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
new char[]{'1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
new char[]{'1', '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
new char[]{'1', '0', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '0', '1', '1', '1', '0', '1', '1', '1'},
new char[]{'0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '0', '1', '1', '1', '1'},
new char[]{'1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '0', '1', '1'},
new char[]{'1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
new char[]{'1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
new char[]{'0', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
new char[]{'1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
new char[]{'1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
new char[]{'1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1'},
new char[]{'1', '0', '1', '1', '1', '1', '1', '0', '1', '1', '1', '0', '1', '1', '1', '1', '0', '1', '1', '1'},
new char[]{'1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '1', '1', '0'},
new char[]{'1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '1', '1', '1', '0', '0'},
new char[]{'1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
new char[]{'1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
new char[]{'1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'}
        };

            char[][] dfsInput = new char[][]
            {
                new char[]{'1','1','1','1','1'},
                new char[]{'1','1','1','1','1'},
                new char[]{'1','1','1','1','1'},
                new char[]{'1','1','1','1','1'}

            };

            var output1 = NumIslandsBFS(bfsInput);
            var output2 = NumIslandsDFS(dfsInput);
            Console.ReadLine();
        }

        public static int NumIslandsDFS(char[][] grid)
        {
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; i++)
                {
                    if(grid[i][j] == '0')
                    {
                        continue;
                    }

                    exploreIslandsDFS(grid, i, j);
                    count++;
                }
            }

            return count;
        }

        private static void exploreIslandsDFS(char[][] grid, int i, int j)
        {
            if(i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] == '0')
            {
                return;
            }

            grid[i][j] = '0';
            exploreIslandsDFS(grid, i - 1, j);
            exploreIslandsDFS(grid, i + 1, j);
            exploreIslandsDFS(grid, i, j - 1);
            exploreIslandsDFS(grid, i, j + 1);
        }
        public static int NumIslandsBFS(char[][] grid)
        {

            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '0')
                    {
                        continue;
                    }

                    grid[i][j] = '0';
                    exploreIslandsBFS(grid, i, j);
                    count++;
                }
            }

            return count;
        }

        private static void exploreIslandsBFS(char[][] grid, int i, int j)
        {

            Queue<List<int>> queue = new Queue<List<int>>();
            queue.Enqueue(new List<int> { i, j });
            while (queue.Count > 0)
            {
                List<int> current = queue.Dequeue();
                int row = current[0];
                int col = current[1];
                List<List<int>> neighbors = getNeighbors(grid, row, col);
                foreach (List<int> neighbor in neighbors)
                {
                    int currentRow = neighbor[0];
                    int currentCol = neighbor[1];
                    if (grid[currentRow][currentCol] == '0')
                    {
                        continue;
                    }
                    grid[currentRow][currentCol] = '0';
                    queue.Enqueue(neighbor);
                }
            }
        }

        private static List<List<int>> getNeighbors(char[][] grid, int i, int j)
        {
            int totalRows = grid.Length;
            int totalCols = grid[i].Length;
            List<List<int>> neighbors = new List<List<int>>();
            if (i - 1 >= 0)
            {
                neighbors.Add(new List<int> { i - 1, j });
            }
            if (j - 1 >= 0)
            {
                neighbors.Add(new List<int> { i, j - 1 });
            }
            if (i + 1 < totalRows)
            {
                neighbors.Add(new List<int> { i + 1, j });
            }
            if (j + 1 < totalCols)
            {
                neighbors.Add(new List<int> { i, j + 1 });
            }

            return neighbors;
        }
    }
}
