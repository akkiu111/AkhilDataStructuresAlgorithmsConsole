using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTicketsHackerrank
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> tickets = new List<int> { 5, 10, 12, 1, 10, 4 };
            var output = getMaxTickets(tickets);
            Console.ReadLine();
        }

        private static int getMaxTickets(List<int> tickets)
        {

            List<int> ticketsList = new List<int>();
            for (int i = 1; i < tickets.Count; i++)
            {
                ticketsList.Add(tickets[i]);
            }

            ticketsList.Sort();
            int runningMaxTickets = 1;
            int maxTickets = 1;

            for (int i = 1; i < ticketsList.Count; i++)
            {
                int diff = ticketsList[i] - ticketsList[i - 1];
                if (diff == 1 || diff == 0)
                {
                    runningMaxTickets++;
                }
                else
                {
                    runningMaxTickets = 1;
                }

                maxTickets = Math.Max(maxTickets, runningMaxTickets);
            }

            return maxTickets;
        }
    }
}
