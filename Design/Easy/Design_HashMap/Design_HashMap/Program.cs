
namespace Design_HashMap
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var hashMap = new MyHashMap();
            hashMap.Put(1, 1);
            hashMap.Put(2, 2);
            hashMap.Get(1);         // returns 1
            hashMap.Get(3);         // returns -1 (not found)
            hashMap.Put(2, 1);      // update the existing value
            hashMap.Get(2);         // returns 1 
            hashMap.Remove(2);      // remove the mapping for 2
            hashMap.Get(2);         // returns -1 (not found) 
        }
    }

    public class MyHashMap
    {
        private ListNode[] nodes = new ListNode[10000];

        /** Initialize your data structure here. */
        public MyHashMap()
        {

        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            int i = GetIndexByKey(key);
            if (nodes[i] == null)
                nodes[i] = new ListNode(-1, -1);

            var prev = GetPreviousNode(nodes[i], key);
            if (prev.next == null)
                prev.next = new ListNode(key, value);
            else
                prev.next.val = value;
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            int index = GetIndexByKey(key);
            if (nodes[index] == null)
                return -1;

            var prev = GetPreviousNode(nodes[index], key);
            return prev.next?.val ?? -1;
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            int index = GetIndexByKey(key);
            if (nodes[index] == null)
                return;

            var prev = GetPreviousNode(nodes[index], key);
            prev.next = prev.next?.next;
        }

        private int GetIndexByKey(int key)
        {
            return key.GetHashCode() % nodes.Length;
        }

        private ListNode GetPreviousNode(ListNode bucket, int key)
        {
            ListNode node = bucket;
            ListNode prev = null;
            while (node != null && node.key != key)
            {
                prev = node;
                node = node.next;
            }

            return prev;
        }

        public class ListNode
        {
            public int key;
            public int val;
            public ListNode next;

            public ListNode(int key, int val)
            {
                this.key = key;
                this.val = val;
            }
        }
    }
}
