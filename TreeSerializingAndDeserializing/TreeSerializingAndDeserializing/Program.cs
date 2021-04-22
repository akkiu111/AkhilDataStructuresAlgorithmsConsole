using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSerializingAndDeserializing
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(-1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(5);

            Codec ser = new Codec();
            Codec deser = new Codec();
            TreeNode ans = deser.deserialize(ser.serialize(root));
            Console.ReadLine();
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public class Codec
        {


            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                string sb = preOrderTraversal(root);
                return sb;
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                Queue<string> queue = new Queue<string>();
                foreach (var ele in data)
                {
                    queue.Enqueue(ele.ToString());
                }


                return deserializing(queue);
            }

            private TreeNode deserializing(Queue<string> queue)
            {
                var current = queue.Dequeue();

                if (current == "x")
                {
                    return null;
                }

                TreeNode final = new TreeNode(Convert.ToInt32(current));
                final.left = deserializing(queue);
                final.right = deserializing(queue);

                return final;

            }

            public string preOrderTraversal(TreeNode tree)
            {
                if (tree == null)
                {
                    return "x";
                }
                string left = preOrderTraversal(tree.left);
                string right = preOrderTraversal(tree.right);

                return tree.val.ToString() + left + right;
            }
        }
    }
}
