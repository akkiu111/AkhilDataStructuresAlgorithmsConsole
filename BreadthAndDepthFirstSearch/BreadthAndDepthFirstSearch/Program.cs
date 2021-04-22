using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthAndDepthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Node graph = new Node("A");
            graph.AddChild("B").AddChild("C").AddChild("D");
            graph.children[0].AddChild("E").AddChild("F");
            graph.children[2].AddChild("G").AddChild("H");
            graph.children[0].children[1].AddChild("I").AddChild("J");
            graph.children[2].children[0].AddChild("K");

            var output1 = graph.DepthFirstSearch(new List<string> { });
            var output2 = graph.BreadthFirstSearch(new List<string> { });
            Console.ReadLine();
        }

        public class Node
        {
            public string name;
            public List<Node> children = new List<Node>();

            public Node(string name)
            {
                this.name = name;
            }

            public Node AddChild(string name)
            {
                Node child = new Node(name);
                children.Add(child);
                return this;
            }

            public List<string> DepthFirstSearch(List<string> array)
            {
                array.Add(this.name);
                foreach(Node child in this.children)
                {
                    child.DepthFirstSearch(array);
                }

                return array;

            }
            public List<string> BreadthFirstSearch(List<string> array)
            {

                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(this);
                
                while(queue.Count > 0)
                {
                    Node current = queue.Dequeue();
                    array.Add(current.name);
                    foreach(Node child in current.children)
                    {
                        queue.Enqueue(child);
                    }
                }
                return array;
            }
        }
    }
}
