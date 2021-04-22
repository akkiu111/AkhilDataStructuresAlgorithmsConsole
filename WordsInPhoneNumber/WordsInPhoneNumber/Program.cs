using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsInPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneNumber = "3662277";
            var words =
              new string[] { "foo", "bar", "baz", "foobar", "emo", "cap", "car", "cat" };
            //	var expected = new List<string>(){
            //	"bar", "cap", "car", "emo", "foo", "foobar"
            //};
            var output = WordsInPhoneNumber(phoneNumber, words);
            Console.ReadLine();
        }


        public static Dictionary<char, char> dictionary = new Dictionary<char, char>(){
            {'a','2'},
            {'b','2'},
            {'c','2'},
            {'d','3'},
            {'e','3'},
            {'f','3'},
            {'g','4'},
            {'h','4'},
            {'i','4'},
            {'j','5'},
            {'k','5'},
            {'l','5'},
            {'m','6'},
            {'n','6'},
            {'o','6'},
            {'p','7'},
            {'q','7'},
            {'r','7'},
            {'s','7'},
            {'t','8'},
            {'u','8'},
            {'v','8'},
            {'w','9'},
            {'x','9'},
            {'y','9'},
            {'z','9'},
        };

        public static List<string> WordsInPhoneNumber(string phoneNumber, string[] words)
        {
            // Write your code here.
            var phoneNumberSuffixTrie = new Trie(phoneNumber);
            var output = new List<string>();
            foreach (var word in words)
            {
                var digitWord = wordToDigits(word);
                if (phoneNumberSuffixTrie.Contains(digitWord))
                {
                    output.Add(word);
                }
            }

            return output;
        }

        private static string wordToDigits(string word)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                builder.Append(dictionary[word[i]]);
            }
            return builder.ToString();
        }

        public class Trie
        {
            public Node root = new Node();

            public Trie(string str)
            {
                populateSuffixTrie(str);
            }

            public void populateSuffixTrie(string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    Insert(str, i);
                }
            }

            public void Insert(string str, int i)
            {
                var node = root;
                for (int j = i; j < str.Length; j++)
                {
                    var val = str[j];
                    if (!node.children.ContainsKey(val))
                    {
                        node.children.Add(val, new Node());
                    }
                    node = node.children[val];
                }
            }

            public bool Contains(string str)
            {
                var node = root;
                foreach (var letter in str)
                {
                    if (!node.children.ContainsKey(letter))
                    {
                        return false;
                    }
                    node = node.children[letter];
                }
                return true;
            }
        }

        public class Node
        {
            public Dictionary<char, Node> children = new Dictionary<char, Node>();
        }
    }

}

