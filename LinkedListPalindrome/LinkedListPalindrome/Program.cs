using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
			var head = new LinkedList(0);
			head.next = new LinkedList(1);
			head.next.next = new LinkedList(2);
            head.next.next.next = new LinkedList(2);
            head.next.next.next.next = new LinkedList(1);
            head.next.next.next.next.next = new LinkedList(0);
            var output = LinkedListPalindromeWithoutUsingAuxDS(head);
            //Console.ReadLine();
        }

		public static bool LinkedListPalindromeWithoutUsingAuxDS(LinkedList head)
		{
			// Write your code here.
			LinkedList current = head;
			int totalCount = 0;
			while (current != null)
			{
				totalCount++;
				current = current.next;
			}
			if (totalCount == 1)
			{
				return true;
			}

			current = head;
			int currentCount = 0;
			int midCount = totalCount / 2;
			while (currentCount != midCount)
			{
				currentCount++;
				current = current.next;
			}

			LinkedList secondHalf = null;

			if (totalCount % 2 == 0)
			{
				secondHalf = current;
			}
			else
			{
				secondHalf = current.next;
			}

			LinkedList prev = null;
			while (secondHalf != null)
			{
				LinkedList next = secondHalf.next;
				secondHalf.next = prev;
				prev = secondHalf;
				secondHalf = next;
			}

			current = head;


			while (currentCount != 0)
			{
				currentCount --;
				if (prev.value == current.value)
				{
					prev = prev.next;
					current = current.next;
				}
				else
				{
					return false;
				}
			}
			return true;
		}

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
	}
}
