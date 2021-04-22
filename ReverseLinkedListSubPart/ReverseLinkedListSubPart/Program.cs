using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseLinkedListSubPart
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node(1);
            node.next = new Node(2);
            node.next.next = new Node(8);
            node.next.next.next = new Node(9);
            node.next.next.next.next = new Node(12);
            node.next.next.next.next.next = new Node(16);

            Node output = reverse(node);
            Console.Write(output.data);
            output = output.next;
            while (output != null)
            {
                Console.Write("--> " + output.data);
                output = output.next;
            }

            Console.WriteLine("\n-------------------------------------\n");
            node = new Node(2);
            node.next = new Node(18);
            node.next.next = new Node(24);
            node.next.next.next = new Node(3);
            node.next.next.next.next = new Node(5);
            node.next.next.next.next.next = new Node(7);
            node.next.next.next.next.next.next = new Node(9);
            node.next.next.next.next.next.next.next = new Node(6);
            node.next.next.next.next.next.next.next.next = new Node(12);

            output = reverse(node); //24, 18, 2, 3, 5, 7, 9, 12, 6
            Console.Write(output.data);
            output = output.next;
            while (output != null)
            {
                Console.Write(" --> " + output.data);
                output = output.next;
            }
            Console.ReadLine();
        }

        public static Node reverse(Node head)
        {
            if (head == null)
                return null;
            Node current = head;
            Node prev = null;

            while (current != null)
            {
                if (current.data % 2 != 0)
                {
                    prev = current;
                    current = current.next;
                    continue;
                }
                Node subPrev = null;
                Node subCurr = current;
                while (subCurr != null && subCurr.data % 2 == 0)
                {
                    Node nextTemp = subCurr.next;
                    subCurr.next = subPrev;
                    subPrev = subCurr;
                    subCurr = nextTemp;
                }
                if (prev != null)
                {
                    prev.next = subPrev;
                }
                else
                {
                    head = subPrev;
                }
                prev = subCurr;
                //if (current != null)
                //{
                    current.next = subCurr;
                //}
                if (subCurr == null)
                    break;
                current = subCurr.next;
            }
            return head;
           // return reverse(head, null);
        }

        static Node reverse(Node head, Node prev)
        {

            // Base case 
            if (head == null)
                return null;

            Node current = head;

            // Reversing nodes until current node's value 
            // turn odd or Linked list is fully traversed 
            while (current != null && current.data % 2 == 0)
            {
                Node nextNode = current.next;
                current.next = prev;
                prev = current;
                current = nextNode;
            }

            // If elements were reversed then head 
            // pointer needs to be changed 
            if (current != head)
            {
                head.next = current;

                // Recur for the remaining linked list 
                reverse(current, null);
                return prev;
            }

            // Simply iterate over the odd value nodes 
            else
            {
                head.next = reverse(head.next, head);
                return head;
            }
        }


        public class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }

    }
}
