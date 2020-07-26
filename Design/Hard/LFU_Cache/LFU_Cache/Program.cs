using System.Collections.Generic;

namespace LFU_Cache
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var cache = new LFUCache(2); // capacity

            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);       // returns 1
            cache.Put(3, 3);    // evicts key 2
            cache.Get(2);       // returns -1 (not found)
            cache.Get(3);       // returns 3.
            cache.Put(4, 4);    // evicts key 1.
            cache.Get(1);       // returns -1 (not found)
            cache.Get(3);       // returns 3
            cache.Get(4);       // returns 4
        }

        public class LFUCache
        {
            public int capacity;
            public int count;
            public int minFrequency;
            public Dictionary<int, DLLNode> cache;
            public Dictionary<int, DoubleLinkedList> frequencyMap;

            public LFUCache(int capacity)
            {
                this.capacity = capacity;
                this.count = 0;
                this.minFrequency = 0;

                this.cache = new Dictionary<int, DLLNode>();
                this.frequencyMap = new Dictionary<int, DoubleLinkedList>();
            }

            public int Get(int key)
            {
                if (!cache.ContainsKey(key))
                    return -1;

                var node = cache[key];
                UpdateNode(node);

                return node.val;
            }

            public void Put(int key, int value)
            {
                if (capacity == 0) // edge case
                {
                    return;
                }

                if (cache.ContainsKey(key)) // update case
                {
                    var current = cache[key];
                    current.val = value;
                    UpdateNode(current);
                }
                else // add case
                {
                    count++;
                    if (count > capacity) // evict
                    {
                        // evict last added node
                        var minFreqList = frequencyMap[minFrequency];
                        var deleteNode = minFreqList.RemoveTail();
                        cache.Remove(deleteNode.key);
                        count--;
                    }

                    minFrequency = 1; // reset
                    if (!frequencyMap.ContainsKey(minFrequency))
                    {
                        frequencyMap.Add(minFrequency, new DoubleLinkedList());
                    }
                    var newNode = new DLLNode(key, value);
                    frequencyMap[minFrequency].Add(newNode); // add to head
                    cache.Add(key, newNode);
                }
            }

            public void UpdateNode(DLLNode current)
            {
                var currentFrequency = current.frequency;
                var currnetFrequencyList = frequencyMap[currentFrequency];
                currnetFrequencyList.Remove(current);

                // case where current node is the last lowest frequency node
                if (currentFrequency == minFrequency && currnetFrequencyList.count == 0)
                {
                    minFrequency++;
                }

                // move to next frequencyMap
                current.frequency++;
                if (!frequencyMap.ContainsKey(current.frequency))
                    frequencyMap.Add(current.frequency, new DoubleLinkedList());

                // add to head
                frequencyMap[current.frequency].Add(current);
            }
        }

        public class DLLNode
        {
            public int key;
            public int val;
            public int frequency;
            public DLLNode prev;
            public DLLNode next;

            public DLLNode(int key, int val)
            {
                this.key = key;
                this.val = val;
                this.frequency = 1;
            }
        }

        public class DoubleLinkedList
        {
            public int count;
            public DLLNode head;
            public DLLNode tail;

            public DoubleLinkedList()
            {
                this.count = 0;
                this.head = new DLLNode(0, 0);
                this.tail = new DLLNode(0, 0);
                head.next = tail;
                tail.prev = head;
            }

            public void Add(DLLNode current)
            {
                var next = head.next;
                current.next = next;
                current.prev = head;
                head.next = current;
                next.prev = current;
                count++;
            }

            public void Remove(DLLNode current)
            {
                var prev = current.prev;
                var next = current.next;
                prev.next = next;
                next.prev = prev;
                count--;
            }

            public DLLNode RemoveTail()
            {
                if (count > 0)
                {
                    var tailNode = tail.prev;
                    Remove(tailNode);
                    return tailNode;
                }

                return null;
            }
        }
    }
}
