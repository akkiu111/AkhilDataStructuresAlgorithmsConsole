using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotationCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = rotationalCipher("Zebra-493?", 3);
            Console.ReadLine();
        }

        private static string rotationalCipher(String input, int rotationFactor)
        {
            if (rotationFactor == 0 || input == null || input == "")
            {
                return input;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (char.IsLetter(ch))
                {
                    int val = (int)ch + rotationFactor;
                    if (char.IsLower(ch))
                    {

                        if (val <= 122)
                        {
                            sb.Append((char)val);
                        }
                        else
                        {
                            sb.Append((char)(96 + (val % 122)));
                        }
                    }
                    else
                    {
                        if (val <= 90)
                        {
                            sb.Append((char)val);
                        }
                        else
                        {
                            sb.Append((char)(64 + (val % 90)));
                        }
                    }
                }
                else if (char.IsDigit(ch))
                {
                    sb.Append((char.GetNumericValue(ch) + rotationFactor) % 10);
                }
                else
                {
                    sb.Append(ch);
                }

            }
            // Write your code here
            return sb.ToString();
        }
    }
}
