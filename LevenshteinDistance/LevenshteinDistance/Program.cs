using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevenshteinDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = 2 == getLevenshteinDistanceOptimalSpace("abc", "yabd");
            Console.ReadLine();

        }

        private static int getLevenshteinDistanceOptimalSpace(string str1, string str2)
        {
            string small = "";
            string big = "";
            if (str1.Length < str2.Length)
            {
                small = str1;
                big = str2;
            }
            else
            {
                small = str2;
                big = str1;
            }

            int[] odd = new int[small.Length + 1];
            int[] even = new int[small.Length + 1];

            for(int i = 0; i < small.Length + 1; i++)
            {
                even[i] = i;
            }

            int[] currentEdits;
            int[] previousEdits;

            for(int i = 1; i < big.Length + 1; i++)
            {
                if(i % 2 == 0)
                {
                    currentEdits = even ;
                    previousEdits = odd ;
                }
                else
                {
                    previousEdits = even ;
                    currentEdits = odd ;
                }
                currentEdits[0] = i;

                for (int j = 1; j < small.Length + 1; j++)
                {
                    if (small[j - 1] != big[i - 1])
                    {
                        currentEdits[j] = Math.Min(Math.Min(currentEdits[j - 1], previousEdits[j]), previousEdits[j - 1]) + 1;
                    }
                    else
                    {
                        currentEdits[j] = previousEdits[j - 1];
                    }
                }

            }

            return big.Length % 2 == 0 ? even[small.Length] : odd[small.Length] ;
        }
        private static int getLevenshteinDistance(string str1, string str2)
        {

            if (str1.Length == 0 && str2.Length == 0)
            {
                return 0;
            }

            if (str1.Length == 0)
            {
                return str2.Length;
            }

            if (str2.Length == 0)
            {
                return str1.Length;
            }
            int[,] dp = new int[str1.Length + 1, str2.Length + 1];
            for (int i = 1; i < str1.Length + 1; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + 1;
                for (int j = 1; j < str2.Length + 1; j++)
                {
                    dp[0, j] = dp[0, j - 1] + 1;
                }
            }

            for (int i = 1; i < str1.Length + 1; i++)
            {
                for (int j = 1; j < str2.Length + 1; j++)
                {
                    if (str1[i - 1] != str2[j - 1])
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                }
            }
            return dp[str1.Length, str2.Length];

        }
    }

}
