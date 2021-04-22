using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BipartiteGraphColoring
{
    class Program
    {
        static void Main(string[] args)
        {
            //[[],[2,4,6],[1,4,8,9],[7,8],[1,2,8,9],[6,9],[1,5,7,8,9],[3,6,9],[2,3,4,6,9],[2,4,5,6,7,8]]
            /*var output = IsBipartite(new int[10][] { new int[] { },
            new int[] { 2,4,6 },
            new int[] { 1,4,8,9},
            new int[] { 7,8 },
            new int[] { 1,2,8,9 },
            new int[] { 6,9 },
            new int[] { 1,5,7,8,9 },
            new int[] { 3,6,9 },
            new int[] { 2,3,4,6,9 },
            new int[] { 2, 4, 5, 6, 7, 8 }
            });
            */
           var output = IsBipartite(new int[4][] { new int[] { 1, 3 },
                new int[] { 0, 2 },new int[] { 1, 3 },new int[] { 0, 2 }});
   
            Console.ReadLine();
        }
        public static bool IsBipartite(int[][] graph)
        {
            Dictionary<int, Colors> colors = new Dictionary<int, Colors>();
            Queue<int> q = new Queue<int>();
            q.Enqueue(0);
            colors.Add(0, Colors.Red);
            while (true)
            {
                while (q.Count > 0)
                {
                    int current = q.Dequeue();
                    Colors neighborColor = colors[current] == Colors.Red ? Colors.Blue : Colors.Red;
                    foreach (var neighbor in graph[current])
                    {
                        if (colors.ContainsKey(neighbor))
                        {
                            if (colors[neighbor] == colors[current])
                            {
                                return false;
                            }
                        }
                        else
                        {
                            q.Enqueue(neighbor);
                            colors.Add(neighbor, neighborColor);
                        }

                    }
                }

                if (colors.Count == graph.Length)
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < graph.Length; i++)
                    {
                        if (!colors.ContainsKey(i))
                        {
                            colors.Add(i, Colors.Red);
                            q.Enqueue(i);
                            break;
                        }
                    }
                }

            }

            return true;
        }

        public enum Colors
        {
            Red,
            Blue
        }
    }
}
