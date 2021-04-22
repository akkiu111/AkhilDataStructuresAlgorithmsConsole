using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InItCap
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = InitCapital("Work Hard To  Get What You Like");
            Console.ReadLine();
        }

        private static string InitCapital(string input)
        {
            string[] words = input.Split(' ').ToArray();
            int count = 0;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (string.IsNullOrWhiteSpace(word))
                {
                    builder.Append(" ");
                }
                else if (char.IsLower(word[0]))
                {
                    builder.Append(convertToUpperAndLower(word));
                }
                else
                {
                    count++;
                    builder.Append(word);

                }

                if (i != words.Length - 1)
                {
                    builder.Append(" ");
                }

            }

            return count == words.Length ? "First Character of each word is already in uppercase" : builder.ToString();

        }

        private static string convertToUpperAndLower(string word)
        {
            char[] chars = new char[word.Length];
            chars[0] = char.ToUpper(word[0]);

            for (int i = 1; i < word.Length; i++)
            {
                char letter = word[i];

                chars[i] = char.ToLower(letter);

            }

            string final = new String(chars);
            return final;
        }
    }
}
