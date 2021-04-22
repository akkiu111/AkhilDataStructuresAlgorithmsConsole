using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelOrderTraversals
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(7);
            root.right.right = new TreeNode(25);
            var output1 = LevelOrder(root);
            var output2 = ZigZagLevelOrder(root);
            var output3 = LevelOrderDFS(root);
            var output4 = LevelOrderDFSZigZag(root);
            var output5 = ZigZagLevelOrderStacks(root);
            Console.ReadLine();
        }


        public static IList<IList<int>> ZigZagLevelOrderStacks(TreeNode root)
        {
            IList<IList<int>> output = new List<IList<int>>();

            if (root == null)
            {
                return output;
            }
            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();

            stack1.Push(root);
            int level = -1;
            while (stack1.Count > 0 || stack2.Count > 0)
            {
                if (stack1.Count > 0)
                {
                    level++;
                    output.Add(new List<int>());

                    while (stack1.Count > 0)
                    {
                        TreeNode node = stack1.Pop();
                        output[level].Add(node.val);
                        if (node.left != null)
                        {
                            stack2.Push(node.left);
                        }
                        if (node.right != null)
                        {
                            stack2.Push(node.right);
                        }
                    }
                }

                if (stack2.Count > 0)
                {
                    level++;
                    output.Add(new List<int>());

                    while (stack2.Count > 0)
                    {
                        TreeNode node = stack2.Pop();
                        output[level].Add(node.val);
                        if (node.left != null)
                        {
                            stack1.Push(node.right);
                        }
                        if (node.right != null)
                        {
                            stack1.Push(node.left);
                        }
                    }
                }
            }

           
            return output;

        }
        public static IList<IList<int>> LevelOrderDFSZigZag(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            Dictionary<int, IList<int>> levels = new Dictionary<int, IList<int>>();
            LevelOrderDFSZigZagHelper(root, 0, levels);

            IList<IList<int>> output = levels.Values.ToList();
            for(int i = 1; i < output.Count; i = i + 2)
            {
                Reverse(output[i]);
            }
            return output;

        }

        public static void LevelOrderDFSZigZagHelper(TreeNode node, int level, Dictionary<int, IList<int>> levels)
        {
            if (node == null)
            {
                return;
            }

            if (!levels.ContainsKey(level))
            {
                levels.Add(level, new List<int>());
            }

            levels[level].Add(node.val);

            LevelOrderDFSHelper(node.left, level + 1, levels);
            LevelOrderDFSHelper(node.right, level + 1, levels);

        }

        public static IList<IList<int>> LevelOrderDFS(TreeNode root)
        {           
            if (root == null)
            {
                return new List<IList<int>>() ;
            }

            Dictionary<int, IList<int>> levels = new Dictionary<int, IList<int>>();
            LevelOrderDFSHelper(root, 0, levels);

            IList<IList<int>> output = levels.Values.ToList();
            return output;

        }

        public static void LevelOrderDFSHelper(TreeNode node, int level, Dictionary<int, IList<int>> levels)
        {
            if(node == null)
            {
                return;
            }

            if(!levels.ContainsKey(level))
            {
                levels.Add(level, new List<int>());
            }

            levels[level].Add(node.val);

            LevelOrderDFSHelper(node.left, level + 1, levels);
            LevelOrderDFSHelper(node.right, level + 1, levels);

        }
        public static IList<IList<int>> ZigZagLevelOrder(TreeNode root)
        {
            IList<IList<int>> output = new List<IList<int>>();

            if (root == null)
            {
                return output;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 0;
            while (queue.Count > 0)
            {
                output.Add(new List<int>());
                int elementsCount = queue.Count;
                while (elementsCount > 0)
                {
                    TreeNode node = queue.Dequeue();
                    output[level].Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                    elementsCount--;
                }


                level++;

            }

            for (int i = 1; i < output.Count; i = i + 2)
            {
                Reverse(output[i]);
            }
            return output;

        }

        public static void Reverse(IList<int> list)
        {
            int i = 0;
            int j = list.Count - 1;
            while (i < j)
            {
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
                i++;
                j--;
            }
        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> output = new List<IList<int>>();

            if (root == null)
            {
                return output;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 0;
            while (queue.Count > 0)
            {
                output.Add(new List<int>());
                int elementsCount = queue.Count;
                for (int i = 0; i < elementsCount; i++)
                {
                    TreeNode node = queue.Dequeue();
                    output[level].Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }

                }
                level++;

            }

            return output;

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
