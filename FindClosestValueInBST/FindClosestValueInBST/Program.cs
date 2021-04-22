using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindClosestValueInBST
{
    class Program
    {
        static void Main(string[] args)
        {
			var root = new Program.BST(10);
			root.left = new Program.BST(5);
			root.left.left = new Program.BST(2);
			root.left.left.left = new Program.BST(1);
			root.left.right = new Program.BST(5);
			root.right = new Program.BST(15);
			root.right.left = new Program.BST(13);
			root.right.left.right = new Program.BST(14);
			root.right.right = new Program.BST(22);


			var expected = 13;
			var actual = Program.FindClosestValueInBst(root, 12);
			var output = expected ==  actual;
			Console.ReadLine();
		}

		public static int FindClosestValueInBst(BST tree, int target)
		{
			// Write your code here.
			// Average Case: T.C is O(log(n)), S.C is O(1) where n is the no. of nodes in a tree
			// Worst Case: T.C is O(n), S.C is O(1) where n is the no. of nodes in a tree
			int closest = target;
			while (tree != null)
			{

				if (tree != null && target < tree.value)
				{
					closest = tree.value;
					tree = tree.left;
				}
				else if (tree != null && target >= tree.value)
				{
					closest = tree.value;
					tree = tree.right;
				}

				else
				{
					break;
				}

			}

			return closest;

		}

		public class BST
		{
			public int value;
			public BST left;
			public BST right;

			public BST(int value)
			{
				this.value = value;
			}
		}
	}
}
