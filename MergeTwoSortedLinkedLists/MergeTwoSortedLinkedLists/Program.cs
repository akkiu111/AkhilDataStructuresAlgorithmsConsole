using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoSortedLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            TestLinkedList list1 = new TestLinkedList(1);
            list1.addMany(new List<int>(){
            2,4
        });
            TestLinkedList list2 = new TestLinkedList(1);
            list2.addMany(new List<int>(){
            3, 4
        });
            TestLinkedList output = (TestLinkedList)mergeLinkedLists(list1, list2);
            List<int> expectedNodes = new List<int>(){
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

            Console.ReadLine();
        }

        public class TestLinkedList : LinkedList
        {
            public TestLinkedList(int val) : base(val)
            {
            }

            public TestLinkedList addMany(List<int> values)
            {
                TestLinkedList current = this;
                while (current.next != null)
                {
                    current = (TestLinkedList)current.next;
                }
                foreach (int value in values)
                {
                    current.next = new TestLinkedList(value);
                    current = (TestLinkedList)current.next;
                }
                return this;
            }

            public List<int> getNodesInArray()
            {
                List<int> nodes = new List<int>();
                TestLinkedList current = this;
                while (current != null)
                {
                    nodes.Add(current.value);
                    current = (TestLinkedList)current.next;
                }
                return nodes;
            }
        }

        // This is an input class. Do not edit.
        public class LinkedList
        {
            public int value;
            public LinkedList next;

            public LinkedList(int value)
            {
                this.value = value;
                this.next = null;
            }
        }

        public static LinkedList mergeLinkedLists(LinkedList headOne, LinkedList headTwo)
        {
            // Write your code here.
            // T.C is O(N+M) and S.C is O(1) where N and M are the number of nodes in the first
            // and second respectively

            var p1 = headOne;
            var p2 = headTwo;
            LinkedList prev = null;

            while (p1 != null && p2 != null)
            {
                if (p1.value < p2.value)
                {
                    prev = p1;
                    p1 = p1.next;
                }
                else
                {
                    if (prev != null)
                    {
                        prev.next = p2;
                    }
                    prev = p2;
                    p2 = p2.next;
                    prev.next = p1;

                }
            }

            if (p1 == null)
            {
                prev.next = p2;
            }
            return headOne.value < headTwo.value ? headOne : headTwo;
        }
    }
}
