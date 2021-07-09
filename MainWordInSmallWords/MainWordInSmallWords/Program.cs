using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWordInSmallWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var smallStrings = new string[] { "foo", "ba", "r", "baz", "az", "a" };
            Console.WriteLine(StringConstruct("foobarbaz", smallStrings));
            smallStrings = new string[] { "foo", "bac", "r", "az", "a" };
            Console.WriteLine(StringConstruct("foobarbaz", smallStrings));
            Console.ReadLine();

        }


        public static bool StringConstruct(string bigstring, string[] smallWords)
        {
            // Write your code here.
            // T.C is O(ns + bs) and  S.C is O(ns) where b is the length of the big string
            // s is the length of the biggeststring in small strings and
            // n is the length of the small string
            Trie trie = new Trie();

            foreach (var str in smallWords)
            {
                trie.insert(str);
            }

            var currentNode = trie.root;
            int i = 0;

            while (i < bigstring.Length)
            {
                var ch = bigstring[i];
                if (currentNode.children.ContainsKey(ch))
                {
                    currentNode = currentNode.children[ch];
                    i++;
                    continue;
                }

                if (currentNode.children.ContainsKey(trie.endSymbol))
                {
                    //if(currentNode.word[currentNode.word.Length - 1] == bigstring[i - 1])
                    //{
                    currentNode = trie.root;
                    continue;
                    //}
                }

                return false;
            }


            return true;
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public string word;
        }
        public class Trie
        {
            public TrieNode root = new TrieNode();
            public char endSymbol = '*';

            public void insert(string str)
            {
                TrieNode node = root;
                for (int i = 0; i < str.Length; i++)
                {
                    var letter = str[i];
                    if (!node.children.ContainsKey(letter))
                    {
                        var newNode = new TrieNode();
                        node.children.Add(letter, newNode);
                    }

                    node = node.children[letter];
                }

                node.children[endSymbol] = null;
                node.word = str;
            }

        }

    }
}
