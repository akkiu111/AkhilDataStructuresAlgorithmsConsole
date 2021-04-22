using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbersLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(0, null);
            
            ListNode l2 = new ListNode(0, null);

            var output = AddTwoNumbers(l1, l2);
            Console.ReadLine();
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int l1Val = getLinkedListValues(l1);
            int l2Val = getLinkedListValues(l2);
            int newLVal = l1Val + l2Val;

            ListNode l = null;
            ListNode next = null;

            if(newLVal == 0)
            {
                return new ListNode(0);
            }

            while (newLVal > 0)
            {
                int currentVal = newLVal % 10;
                l = new ListNode(currentVal, next);
                next = l;
                newLVal = newLVal / 10;
            }

            return ReverseLinkedList(l);
        }

        private static ListNode ReverseLinkedList(ListNode head)
        {
            // Write your code here.
            // T.C is O(N) and S.C is O(1) where N is the no. of Nodes in a Linked List
            ListNode p1 = null;
            ListNode p2 = head;

            while (p2 != null)
            {
                ListNode p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
            }


            return p1;
        }

        private static int getLinkedListValues(ListNode linkedList)
        {
            ListNode current = linkedList;
            int power = 0;
            double totalValue = 0;
            while (current != null)
            {
                totalValue = totalValue + (current.val * Math.Pow(10, power));
                power++;
                current = current.next;
            }

            return (int)totalValue;
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
