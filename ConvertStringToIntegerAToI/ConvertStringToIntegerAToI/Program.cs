using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertStringToIntegerAToI
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = ConversionOfStringToInt("-9223372036854775809");
            Console.ReadLine();
        }

        private static int ConversionOfStringToInt(string s)
        {
            int ans = 0;
            int i = 0, sign = 1, state = 0;

            while (i < s.Length)
            {
                if (state == 0)
                {
                    if (s[i] == ' ')
                    {

                    }
                    else if (s[i] == '+' || s[i] == '-')
                    {
                        state = 1;
                        if (s[i] == '+')
                        {
                            sign = 1;
                        }
                        else if (s[i] == '-')
                        {
                            sign = -1;
                        }
                    }
                    else if (char.IsDigit(s[i]))
                    {
                        state = 2;
                        ans = ans * 10 + (int)char.GetNumericValue(s[i]);
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (state == 1)
                {
                    if (char.IsDigit(s[i]))
                    {
                        state = 2;
                        ans = ans * 10 + (int)char.GetNumericValue(s[i]);
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (state == 2)
                {
                    if (!char.IsDigit(s[i]))
                    {
                        break;
                    }
                    if (ans > int.MaxValue / 10)
                    {
                        return sign == 1 ? int.MaxValue : int.MinValue;
                    }
                    else if (ans == int.MaxValue / 10)
                    {
                        if (sign == 1 && (int)char.GetNumericValue(s[i]) > 6)
                        {
                            return int.MaxValue;
                        }
                        else if (sign == -1 && (int)char.GetNumericValue(s[i]) > 7)
                        {
                            return int.MinValue;
                        }
                    }
                    ans = ans * 10 + (int)char.GetNumericValue(s[i]);
                }
                else
                {
                    return 0;
                }
                i++;
            }

            ans = ans * sign;

            return ans;
        }
    }
}
