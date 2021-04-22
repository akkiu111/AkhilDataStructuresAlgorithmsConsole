using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputUniqieCharactersInSentence
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = UniqueCharacters("LIfe is inherently risky");
            Console.Read();
        }

        private static string UniqueCharacters(string sentence)
        {
            string[] inputArray = sentence.Split(' ').ToArray();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < inputArray.Length; i++)
            {
                string word = inputArray[i].ToLower();
                Dictionary<char, int> uniqueCharacters = new Dictionary<char, int>();
                for (int j = 0; j < word.Length; j++)
                {
                    char letter = word[j];
                    if (!uniqueCharacters.ContainsKey(letter))
                    {
                        uniqueCharacters.Add(letter, 1);
                    }
                    else
                    {
                        uniqueCharacters[letter] = uniqueCharacters[letter] + 1;
                    }
                }

                foreach(var letter in uniqueCharacters)
                {
                    if (letter.Value == 1)
                    {
                        output.Append(letter.Key);
                    }
                }

                if (i != inputArray.Length - 1)
                {
                    output.Append(" ");
                }
            }

            return output.ToString();
        }
    }
}
