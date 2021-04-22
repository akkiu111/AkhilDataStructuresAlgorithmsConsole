using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.right = new TreeNode(5);
            var output = BinaryTreePaths(root);
            Console.ReadLine();
        }

        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            IList<string> paths = new List<string>();
            if (root == null)
            {
                return paths;
            }
            addPaths(root, new StringBuilder(), paths);
            return paths;
        }

        public static void addPaths(TreeNode node, StringBuilder path, IList<string> paths)
        {
            if (node == null)
            {
                return;
            }

            int length = path.Length;
            path.Append(node.val);
            if (node.left == null && node.right == null)
            {
                paths.Add(path.ToString());
            }
            else
            {
                path.Append("->");
                addPaths(node.left, path, paths);
                addPaths(node.right, path, paths);
            }

            path.Length = length;
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
