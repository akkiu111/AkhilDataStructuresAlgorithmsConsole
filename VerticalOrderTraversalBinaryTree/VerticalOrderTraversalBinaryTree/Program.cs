using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalOrderTraversalBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeNode node = new TreeNode(3);
            //node.left = new TreeNode(9);
            //node.left.left = new TreeNode(4);
            //node.left.right = new TreeNode(0);
            //node.left.right.right = new TreeNode(2);
            //node.right = new TreeNode(8);
            //node.right.left = new TreeNode(1);
            //node.right.left.left = new TreeNode(5);
            //node.right.right = new TreeNode(7);
            //var output = VerticalOrder(node);
            var output = VerticalOrder(new TreeNode(1));
            Console.ReadLine();
        }

        public static int minIndex = int.MaxValue;
        public static int maxIndex = int.MinValue;


        public static IList<IList<int>> VerticalOrder(TreeNode root)
        {
            Dictionary<int, IList<int>> dt = new Dictionary<int, IList<int>>();
            IList<IList<int>> list = new List<IList<int>>();
            if (root == null)
            {
                return list;
            }

            TraverseAndUpdateList(root, dt, 0);

            while (minIndex <= maxIndex)
            {
                list.Add(dt[minIndex]);
                minIndex++;
            }
            return list;
        }

        public static void TraverseAndUpdateList(TreeNode node, Dictionary<int, IList<int>> dt, int level)
        {
            if (node == null)
            {
                return;
            }
            Queue<TreeInfo> q = new Queue<TreeInfo>();
            q.Enqueue(new TreeInfo(node, level));
            while (q.Count > 0)
            {
                TreeInfo current = q.Dequeue();
                level = current.level;
                if (!dt.ContainsKey(level))
                {
                    dt.Add(current.level, new List<int> { current.node.val });
                }
                else
                {
                    dt[level].Add(current.node.val);
                }

                minIndex = Math.Min(minIndex, level);
                maxIndex = Math.Max(maxIndex, level);
                if (current.node.left != null)
                {
                    q.Enqueue(new TreeInfo(current.node.left, level - 1));
                }
                if (current.node.right != null)
                {
                    q.Enqueue(new TreeInfo(current.node.right, level + 1));
                }

            }

        }

        public class TreeInfo
        {
            public TreeNode node;
            public int level;

            public TreeInfo(TreeNode node, int level)
            {
                this.node = node;
                this.level = level;
            }
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
