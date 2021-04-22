// The stock data problem can be solved similarly for stock symbol by making stock symbol as the key 
// in dictionary and with slight modifications. Previously, I thought that min max stack would be necessary
// but its not as I could just update min and max values in class variables everytime I insert or update the stock price
// which can be accesssed by its class methods while storing the time and stock prices in the dictionary
// and by maintaining the list of time values for doing modified binary search later for getstockValues function,
// since input time is in ascending order that means timelist is already sorted which helps in not sorting again 
// so that avoids doing a sort which has O(nlogn) time complexity.

using System;
using System.Collections.Generic;

namespace StockPriceQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            StockData stocks = new StockData();

            stocks.InsertUpdateStocks("9:30:45:989 AM", "140");
            stocks.InsertUpdateStocks("9:40:00:000 AM", "100");
            stocks.InsertUpdateStocks("9:40:10:100 AM", "101");
            stocks.InsertUpdateStocks("9:40:10:200 AM", "109");
            stocks.InsertUpdateStocks("9:40:10:300 AM", "102");
            stocks.InsertUpdateStocks("9:40:10:400 AM", "103");
            stocks.InsertUpdateStocks("9:40:10:500 AM", "104");
            stocks.InsertUpdateStocks("9:40:10:600 AM", "105");
            stocks.InsertUpdateStocks("9:40:10:700 AM", "106");
            stocks.InsertUpdateStocks("9:40:10:800 AM", "107");
            stocks.InsertUpdateStocks("9:40:10:900 AM", "108");

            string output = stocks.GetStockPrices("9:40:00:000 AM");

            stocks.InsertUpdateStocks("9:50:00:000 AM", "130");
            stocks.InsertUpdateStocks("10:00:00:000 AM", "1070");
            stocks.InsertUpdateStocks("10:15:00:000 AM", "110");
            stocks.InsertUpdateStocks("10:20:45:589 AM", "160");
            stocks.InsertUpdateStocks("10:30:00:000 AM", "150");

            output = stocks.GetStockPrices("10:15:00:000 AM");

            stocks.InsertUpdateStocks("10:40:00:000 AM", "120");
            stocks.InsertUpdateStocks("12:40:00:000 PM", "1020");

            stocks.InsertUpdateStocks("9:40:00:000 AM", null);

            output = stocks.GetStockPrices("9:51:00:000 AM");
            stocks.InsertUpdateStocks("1:40:00:000 PM", "1420");
            stocks.InsertUpdateStocks("2:40:00:000 PM", "1920");
            stocks.InsertUpdateStocks("02:41:00:000 PM", "1980");
            output = stocks.GetStockPrices("02:41:00:000 PM");



            Console.ReadLine();
        }


        //Can be solved similarly for stock symbol as well by making stock symbol as the key in dictionary and with slight modifications

        public class StockData
        {
            Dictionary<string, decimal> Stocks = new Dictionary<string, decimal>();
            List<long> TimeList = new List<long>();
            decimal minPrice = decimal.MaxValue;
            decimal maxPrice = decimal.MinValue;

            // Space Complexity is O(1) (constant space), Time Complexity is O(logm) where m is the total number of timestamps 
            // recieved so far and As binary search of closest time to input time has logarithmic complexity which is more than
            // the closest current time's constant time look up in dictionary of stocks       

            public string GetStockPrices(string time)
            {
                string closestTime = GetClosestTimeBinarySearch(TimeList, long.Parse(GetTimeinRequiredFormat(time)));
                string currentPrice = Stocks[closestTime] == -1 ? "null" : Stocks[closestTime].ToString();
                return $"Current: {currentPrice}, Highest: {maxPrice}, Lowest: {minPrice}";
            }

            // Space Complexity is O(1) constant space and Time Complexity is O(t + n) where t is the input time length and n is the total number of stock prices.
            // Along with insertion and updation of the time stamp and its corresponding stock prices we are simultaneously updating
            // the minimum and maximum values of stock prices by tarversing through all stock price values recieved in data stream till that moment

            public void InsertUpdateStocks(string timeString, string stockPrice)
            {
                string time = GetTimeinRequiredFormat(timeString);
                decimal price = stockPrice == null ? -1 : Convert.ToDecimal(stockPrice);

                if (!Stocks.ContainsKey(time))
                {
                    Stocks.Add(time, price);
                    TimeList.Add(long.Parse(time));
                }
                else
                {
                    if (minPrice == Stocks[time])
                    {
                        minPrice = decimal.MaxValue;
                    }

                    if (maxPrice == Stocks[time])
                    {
                        maxPrice = decimal.MinValue;
                    }
                    Stocks[time] = price;
                }

                foreach (decimal val in Stocks.Values)
                {
                    if (val != -1)
                    {
                        minPrice = Math.Min(val, minPrice);
                        maxPrice = Math.Max(val, maxPrice);
                    }
                }
            }

            //Converting the given input string into required format by using a stack and working backwards for the conversion

            private string GetTimeinRequiredFormat(string timeString)
            {
                double finalTime = 0;
                double powValue = 0;
                bool add12 = false;
                Stack<int> stackTime = new Stack<int>();

                if(timeString[timeString.Length - 2].ToString().ToUpper() == "P")
                {
                    if (timeString[1] == ':' || (timeString[2] == ':' && timeString[0] != '1')) {
                        add12 = true;
                    }
                }

                foreach (char val in timeString)
                {
                    if (char.IsDigit(val))
                    {
                        stackTime.Push(Convert.ToInt32(val.ToString()));
                    }
                }

                while (stackTime.Count > 0)
                {
                    finalTime = finalTime + (stackTime.Pop() * Math.Pow(10, powValue));
                    powValue = powValue + 1;
                }

                if (add12)
                {
                    finalTime = Add12Format(finalTime);
                }

                return finalTime.ToString();
            }

            private double Add12Format(double finalTime)
            {
                finalTime = finalTime + 12 * Math.Pow(10, 7);
                return finalTime;
            }

            // Modified binary search to get the closest time stock price

            private string GetClosestTimeBinarySearch(List<long> timeList, long time)
            {
                int start = 0;
                int end = timeList.Count - 1;
                if (time <= timeList[start])
                {
                    return timeList[start].ToString();
                }

                if (time >= timeList[end])
                {
                    return timeList[end].ToString();
                }

                while (start <= end)
                {
                    if (time <= timeList[start])
                    {
                        return timeList[start - 1].ToString();
                    }

                    if (time >= timeList[end])
                    {
                        return timeList[end].ToString();
                    }

                    int mid = (start + end) / 2;

                    if (time == timeList[mid])
                    {
                        break;
                    }

                    if (time > timeList[mid])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }

                return time.ToString();
            }

        }

    }
}