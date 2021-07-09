using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTwoBinaryTreesRInorder
{
    class Program
    {
        static void Main(string[] args)
        {

            Tree tree1 = new Tree(3);
            tree1.left = new Tree(4);
            tree1.left.left = new Tree(5);
            tree1.right = new Tree(6);
            tree1.right.right = new Tree(7);

            Tree tree2 = new Tree(4);
            tree2.left = new Tree(5);
            tree2.right = new Tree(6);
            tree2.right.left = new Tree(3);
            tree2.right.right = new Tree(7);


            var output = hasSameInorderTraversalForTwoTrees(tree1, tree2);
            Console.WriteLine(output);

            tree2.right.left.left = new Tree(8);
            output = hasSameInorderTraversalForTwoTrees(tree1, tree2);
            Console.WriteLine(output);

            Console.ReadLine();

        }

        private static object locker = new object();

        public static bool proceedFirst = false;
        public static bool proceedSecond = false;

        public static int element;

        public static bool hasSameInorderTraversalForTwoTrees(Tree tree1, Tree tree2)
        {

            Thread thread = new Thread(() => hasSameInorderTraversalTree2(tree2));

            thread.Start();

            return hasSameInorderTraversalTree1(tree1);

        }

        public static bool hasSameInorderTraversalTree1(Tree root1)
        {

            if (root1 == null)
            {
                return true;
            }

            if (!hasSameInorderTraversalTree1(root1.left))
            {
                return false;
            }

            lock (locker)
            {
                proceedFirst = false;
                while (!proceedFirst)
                {
                    Monitor.Pulse(locker);
                    proceedFirst = true;
                    proceedSecond = true;
                }

                Monitor.Wait(locker);
            }

            if (root1.data != element)
            {
                return false;
            }

            return hasSameInorderTraversalTree1(root1.right);

        }

        public static void hasSameInorderTraversalTree2(Tree root2)
        {
            if (root2 == null)
            {
                return;
            }

            hasSameInorderTraversalTree2(root2.left);

            lock (locker)
            {
                while (!proceedSecond)
                {
                    Monitor.Wait(locker);
                }

                element = root2.data;
                proceedFirst = true;
                proceedSecond = false;
                Monitor.Pulse(locker);
            }

            hasSameInorderTraversalTree2(root2.right);

        }


        public class Tree
        {
            public int data;
            public Tree left;
            public Tree right;

            public Tree(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }
    }
}



//using System;
//using System.Threading;
//using System.Diagnostics;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CheckTwoBinaryTreesRInorder
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            Tree tree1 = new Tree(3);
//            tree1.left = new Tree(4);
//            tree1.left.left = new Tree(5);
//            tree1.right = new Tree(6);
//            tree1.right.right = new Tree(7);

//            Tree tree2 = new Tree(4);
//            tree2.left = new Tree(5);
//            tree2.right = new Tree(6);
//            tree2.right.left = new Tree(3);
//            tree2.right.right = new Tree(7);

//            var stopwatch = Stopwatch.StartNew();
//            var output = hasSameInorderTraversalForTwoTrees(tree1, tree2);
//            Console.WriteLine(output);
//            Console.WriteLine(stopwatch.ElapsedMilliseconds);
//            Console.ReadLine();

//        }

//        private static ManualResetEvent mre = new ManualResetEvent(false);
//        private static object locker = new object();

//        public static bool proceedFirst = false;
//        public static bool proceedSecond = false;

//        public static int element;

//        public static bool hasSameInorderTraversalForTwoTrees(Tree tree1, Tree tree2)
//        {

//            Thread thread = new Thread(() => hasSameInorderTraversalTree2(tree2));

//            thread.Start();

//            return hasSameInorderTraversalTree1(tree1);

//        }

//        public static bool hasSameInorderTraversalTree1(Tree root1)
//        {

//            if (root1 == null)
//            {
//                return true;
//            }

//            if (!hasSameInorderTraversalTree1(root1.left))
//            {
//                return false;
//            }

//            lock (locker)
//            {
//                proceedFirst = false;
//                while (!proceedFirst)
//                {
//                    proceedSecond = true;
//                    Monitor.Wait(locker);
//                }

//                Monitor.Pulse(locker);
//            }

//            if (root1.data != element)
//            {
//                return false;
//            }

//            return hasSameInorderTraversalTree1(root1.right);

//        }

//        public static void hasSameInorderTraversalTree2(Tree root2)
//        {
//            if (root2 == null)
//            {
//                return;
//            }

//            hasSameInorderTraversalTree2(root2.left);

//            lock (locker)
//            {
//                while (!proceedSecond)
//                {
//                    Monitor.Wait(locker);
//                }

//                element = root2.data;
//                proceedFirst = true;
//                proceedSecond = false;
//                Monitor.Pulse(locker);
//            }

//            hasSameInorderTraversalTree2(root2.right);

//        }


//        public class Tree
//        {
//            public int data;
//            public Tree left;
//            public Tree right;

//            public Tree(int data)
//            {
//                this.data = data;
//                left = null;
//                right = null;
//            }
//        }
//    }
//}
