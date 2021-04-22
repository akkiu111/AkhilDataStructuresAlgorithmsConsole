using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache lruCache = new Program.LRUCache(3);
            lruCache.InsertKeyValuePair("b", 2);
            lruCache.InsertKeyValuePair("a", 1);
            lruCache.InsertKeyValuePair("c", 3);
            var output = lruCache.GetMostRecentKey() == "c";
            output = lruCache.GetValueFromKey("a").value == 1;
            output = lruCache.GetMostRecentKey() == "a";
            lruCache.InsertKeyValuePair("d", 4);
            var evictedValue = lruCache.GetValueFromKey("b");
            var isTrue = evictedValue == null || evictedValue.found == false;
            lruCache.InsertKeyValuePair("a", 5);
            output = lruCache.GetValueFromKey("a").value == 5;
            Console.ReadLine();
        }


        public class LRUCache
        {
            public int maxSize;
            public Dictionary<string, Node> cache = new Dictionary<string, Node>();
            public DLL listOfFrequentlyUsed = new DLL();
            public int currentSize = 0;

            public LRUCache(int maxSize)
            {
                this.maxSize = maxSize > 1 ? maxSize : 1;
            }

            public void InsertKeyValuePair(string key, int value)
            {
                if (currentSize == maxSize)
                {
                    evictLeastRecentlyUsed();
                    currentSize--;
                }
                if (!cache.ContainsKey(key))
                {
                    cache.Add(key, new Node(key, value));
                    currentSize++;
                }
                else
                {
                    cache[key].value = value;
                }
                updateMostRecentlyUsed(cache[key]);
                // Write your code here.
            }

            public LRUResult GetValueFromKey(string key)
            {
                // Write your code here.
                if (cache.ContainsKey(key))
                {
                    updateMostRecentlyUsed(cache[key]);
                    return new LRUResult(true, cache[key].value);
                }

                return new LRUResult(false, -1);
            }

            public string GetMostRecentKey()
            {
                // Write your code here.
                if (listOfFrequentlyUsed.head == null)
                {
                    return null;
                }
                Node node = listOfFrequentlyUsed.head;
                //updateMostRecentlyUsed(node);
                return node.key;
            }

            public void evictLeastRecentlyUsed()
            {
                Node tail = listOfFrequentlyUsed.tail;
                if (tail == null)
                {
                    return;
                }
                if (cache.ContainsKey(tail.key))
                {
                    cache.Remove(tail.key);
                    listOfFrequentlyUsed.removeTail();
                }
                else
                {
                    return;
                }
            }

            public void updateMostRecentlyUsed(Node node)
            {
                listOfFrequentlyUsed.setHead(node);
            }
        }

        public class LRUResult
        {
            public bool found;
            public int value;

            public LRUResult(bool found, int value)
            {
                this.found = found;
                this.value = value;
            }
        }

        public class DLL
        {
            public Node head = null;
            public Node tail = null;

            public void setHead(Node node)
            {
                if (head == node)
                {
                    return;
                }

                if (head == null)
                {
                    head = node;
                    tail = node;
                    return;
                }

                if (head == tail)
                {
                    head.prev = node;
                    node.next = head;
                    head = node;
                    return;
                }
                else
                {
                    if (tail == node)
                    {
                        removeTail();
                    }

                    node.removeNodeBindings();
                    head.prev = node;
                    node.next = head;
                    head = node;
                }
            }

            public void removeTail()
            {
                if (tail == null)
                {
                    return;
                }
                if (tail == head)
                {
                    tail = null;
                    head = null;
                    return;
                }
                tail = tail.prev;
                tail.next = null;
            }
        }

        public class Node
        {
            public Node prev = null;
            public Node next = null;
            public string key;
            public int value;
            public Node(string key, int value)
            {
                this.key = key;
                this.value = value;
            }

            public void removeNodeBindings()
            {
                if (prev != null)
                {
                    prev.next = next;
                }

                if (next != null)
                {
                    next.prev = prev;
                }

                prev = null;
                next = null;
            }
        }

    }
}
