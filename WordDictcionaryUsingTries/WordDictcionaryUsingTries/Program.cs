using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDictcionaryUsingTries
{
    class Program
    {
        static void Main(string[] args)
        {
            //["WordDictionary","addWord","addWord","addWord","addWord","search","search","addWord","search","search","search","search","search","search"]
            //[[],["at"],["and"],["an"],["add"],["a"],[".at"],["bat"],[".at"],["an."],["a.d."],["b."],["a.d"],["."]]
            //[null,null,null,null,null,false,false,null,true,true,false,false,true,false]
            WordDictionary wordDictionary = new WordDictionary();
            wordDictionary.AddWord("at");
            wordDictionary.AddWord("and");
            wordDictionary.AddWord("an");
            wordDictionary.AddWord("add");

           var output = wordDictionary.Search("a"); // return False
            output = wordDictionary.Search(".at");// return False
            wordDictionary.AddWord("bat");
            output = wordDictionary.Search(".at"); // return True
            output = wordDictionary.Search("an."); // return true
            output = wordDictionary.Search("a.d."); // return false
            output = wordDictionary.Search("b."); // return false
            output = wordDictionary.Search("a.d"); // return True
            output = wordDictionary.Search("."); // return false
            Console.ReadLine();
        }

        

        public class WordDictionary
        {
            public class TrieNode
            {
                public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            }


            /** Initialize your data structure here. */

            public TrieNode root;
            public char endSymbol = '*';

            public WordDictionary()
            {

                root = new TrieNode();
            }

            public void AddWord(string word)
            {
                populateTrie(word);
            }

            public bool Search(string word)
            {
                TrieNode node = root;
                return Searching(word, 0, node);
            }

            public bool Searching(string word, int index, TrieNode node)
            {
                if (index == word.Length)
                {
                    return node.children.ContainsKey(endSymbol);
                }

                char letter = word[index];

                if (letter == '.')
                {
                    foreach (TrieNode childNode in node.children.Values)
                    {
                        if (childNode != null)
                        {
                            if (Searching(word, index + 1, childNode))
                            {
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    if (!node.children.ContainsKey(letter))
                    {
                        return false;
                    }

                    return Searching(word, index + 1, node.children[letter]);
                }

                return false;
            }


            private void populateTrie(string word)
            {
                TrieNode node = root;
                for (int i = 0; i < word.Length; i++)
                {
                    char letter = word[i];
                    if (!node.children.ContainsKey(letter))
                    {

                        node.children.Add(letter, new TrieNode());
                    }
                    node = node.children[letter];
                }

                node.children[endSymbol] = null;
            }

        
        }
    }
}
