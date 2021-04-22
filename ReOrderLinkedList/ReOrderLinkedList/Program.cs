using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReOrderLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list1 = new ListNode(1);
            list1.next = new ListNode(2);
            list1.next.next = new ListNode(3);
            list1.next.next.next = new ListNode(4);
            list1.next.next.next.next = new ListNode(5);
            list1.next.next.next.next.next = new ListNode(6);



            ReorderList(list1);
            Console.ReadLine();
        }
        public class TestListNode : Program.ListNode
        {
            public TestListNode(int val) : base(val)
            {
            }

            public TestListNode addMany(List<int> values)
            {
                TestListNode current = this;
                while (current.next != null)
                {
                    current = (TestListNode)current.next;
                }
                foreach (int value in values)
                {
                    current.next = new TestListNode(value);
                    current = (TestListNode)current.next;
                }
                return this;
            }

            public List<int> getNodesInArray()
            {
                List<int> nodes = new List<int>();
                TestListNode current = this;
                while (current != null)
                {
                    nodes.Add(current.val);
                    current = (TestListNode)current.next;
                }
                return nodes;
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static void ReorderList(ListNode head)
        {
            //Find middle
            if (head == null)
            {
                return;
            }
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            //Reverse linked list from middle to end;

            ListNode reverseHead = slow;
            ListNode prev = null;
            while (reverseHead != null)
            {
                ListNode temp = reverseHead;
                reverseHead = reverseHead.next;
                temp.next = prev;
                prev = temp;
            }

            // Merge 1st half  and reversed linked lists

            ListNode second = prev;
            ListNode firstHalf = head;
            while (second.next != null)
            {
                ListNode tempNext = firstHalf.next;
                firstHalf.next = second;
                firstHalf = tempNext;
                tempNext = second.next;
                second.next = firstHalf;
                second = tempNext;

            }

        }
    }
}
