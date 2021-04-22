using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeaserCipherEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
			var output = CaesarCypherEncryptor("xyz", 2);
			Console.ReadLine();

		}

		public static string CaesarCypherEncryptor(string str, int key)
		{
			// Write your code here.

			string alphabets = "abcdefghijklmnopqrstuvwxyz";

			key = key > 0 ? key % 26 : 26 - (Math.Abs(key) % 26);

			char[] charArray = new char[str.Length];
			for (int i = 0; i < str.Length; i++)
			{
				char alphabet = str[i];
				int alphabetIndex = alphabets.IndexOf(alphabet);
				int shiftedIndex = (alphabetIndex + key) % 26;
				alphabet = alphabets[shiftedIndex];
				charArray[i] = alphabet;
			}

			return new String(charArray);
		}
	}
}
