using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiStringSearchSuffixTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            List<bool> output = Program.MultistringSearch("Mary goes to the shopping center every week.",
            new string[] {"to",
    "Mary",
    "centers",
    "shop",
    "shopping",
    "string",
    "kappa"});

            Console.ReadLine();
        }

        public static List<bool> MultistringSearch(string bigstring, string[] smallstrings)
        {
            // Write your code here.
            TrieSuffix trie = new TrieSuffix();
            foreach (string small in smallstrings)
            {
                trie.InsertString(small);
            }

            HashSet<string> containedStrings = new HashSet<string>();

            for (int i = 0; i < bigstring.Length; i++)
            {
                matchBigString(bigstring, i, trie, containedStrings);
            }
            
            return populateBooleanStrings(smallstrings, containedStrings);
        }

        private static List<bool> populateBooleanStrings(string[] smallstrings, HashSet<string> containedStrings)
        {
            List<bool> existsList = new List<bool>();
            foreach(string small in smallstrings)
            {
                existsList.Add(containedStrings.Contains(small));
            }

            return existsList;
        }

        private static void matchBigString(string bigstring, int startIdx, TrieSuffix trie, HashSet<string> containedStrings)
        {
            TrieNode node = trie.root;
            for (int i = startIdx; i < bigstring.Length; i++)
            {
                char ch = bigstring[i];
                if (!node.children.ContainsKey(ch))
                {
                    break;
                }

                node = node.children[ch];

                if (node.children.ContainsKey(trie.endSymbol))
                {
                    containedStrings.Add(node.word);
                }          
            }
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public string word;

        }
        public class TrieSuffix
        {
            public TrieNode root = new TrieNode();
            public char endSymbol = '*';

            public void InsertString(string str)
            {
                TrieNode node = root;
                for (int i = 0; i < str.Length; i++)
                {
                    char ch = str[i];
                    if (!node.children.ContainsKey(ch))
                    {
                        node.children.Add(ch, new TrieNode());
                    }

                    node = node.children[ch];
                }

                node.children[endSymbol] = null;
                node.word = str;
            }

            
        }
    }
}
