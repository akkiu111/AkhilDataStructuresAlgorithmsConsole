using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode node = buildLinkedList(new int[] { 1, 2, 8, 9, 12 });
            var output = OddEvenList(node);
            Console.ReadLine();
        }

        public static ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
            {
                return head;
            }
            ListNode oddHead = head;
            ListNode evenHead = head.next;
            ListNode evenTail = evenHead;

            while (evenTail != null && evenTail.next != null)
            {
                oddHead.next = oddHead.next.next;
                evenTail.next = evenTail.next.next;
                oddHead = oddHead.next;
                evenTail = evenTail.next;
            }

            oddHead.next = evenHead;
            return head;

        }
        public static ListNode buildLinkedList(int[] list)
        {
            ListNode Head = new ListNode(list[0]);
            ListNode node = Head;
            for (int i = 1; i < list.Length; i++)
            {
                node.next = new ListNode(list[i]);
                node = node.next;
            }
            return Head;
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
    }
}
