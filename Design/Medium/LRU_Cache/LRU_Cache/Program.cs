using System.Collections.Generic;

namespace LRU_Cache
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);
            cache.Put(3, 3);
            cache.Get(2);
            cache.Put(4, 4);
            cache.Get(1);
            cache.Get(3);
            cache.Get(4);
        }

        public class LRUCache
        {
            private int _count;
            private int _capacity;
            private LRUCacheNode _head;
            private LRUCacheNode _tail;
            private Dictionary<int, LRUCacheNode> _map = new Dictionary<int, LRUCacheNode>();

            public LRUCache(int capacity)
            {
                _capacity = capacity;
            }

            public int Get(int key)
            {
                if (!_map.ContainsKey(key))
                    return -1;

                var node = _map[key];
                if (_head == node)
                    return node.val;
                else if (node == _tail)
                    RemoveTail();
                else
                    RemoveNode(node);

                MoveToHead(node);

                return _head.val;
            }

            public void Put(int key, int value)
            {
                if (_map.ContainsKey(key))
                {
                    var node = _map[key];
                    node.val = value;

                    if (_head == node)
                        return;
                    else if (node == _tail)
                        RemoveTail();
                    else
                        RemoveNode(node);

                    MoveToHead(node);
                }
                else
                {
                    var node = new LRUCacheNode(key, value);
                    _map.Add(key, node);
                    if (_count == _capacity) // evicts
                    {
                        MoveToHead(node);
                        _map.Remove(_tail.key);
                        RemoveTail();
                    }
                    else
                    {
                        if (_head == null) // count 0
                        {
                            _head = _tail = node;
                        }
                        else if (_head == _tail) // count 1
                        {
                            _tail.prev = node;
                            node.next = _tail;
                            _head = node;
                        }
                        else
                        {
                            MoveToHead(node);
                        }
                        _count++;
                    }
                }
            }

            private void MoveToHead(LRUCacheNode node)
            {
                _head.prev = node;
                node.next = _head;
                node.prev = null;
                _head = node;
            }

            private void RemoveNode(LRUCacheNode node)
            {
                var prev = node.prev;
                var next = node.next;
                if (prev != null)
                {
                    prev.next = next;
                }
                if (next != null)
                {
                    next.prev = prev;
                }
            }

            private void RemoveTail()
            {
                _tail = _tail.prev;
                _tail.next = null;
            }

            public class LRUCacheNode
            {
                public LRUCacheNode prev { get; set; }
                public LRUCacheNode next { get; set; }
                public int key { get; set; }
                public int val { get; set; }

                public LRUCacheNode(int key, int val)
                {
                    this.key = key;
                    this.val = val;
                }
            }
        }
    }
}
