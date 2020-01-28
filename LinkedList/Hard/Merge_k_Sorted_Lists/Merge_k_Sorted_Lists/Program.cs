using System.Collections.Generic;

namespace Merge_k_Sorted_Lists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var first = new ListNode(1);
            first.next = new ListNode(4);
            first.next.next = new ListNode(5);
            var second = new ListNode(1);
            second.next = new ListNode(3);
            second.next.next = new ListNode(4);
            var third = new ListNode(2);
            third.next = new ListNode(6);
            var lists = new ListNode[]
            {
                first,
                second,
                third
            };

            var result = MergeKLists(lists);
        }

        /// <summary>
        /// Time Complexity: O(NKlogK) where N is total elements of given ListNode array lists and K is length of lists
        /// Space Complexity: O(N)
        /// </summary>
        private static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;

            var heap = new Heap();
            foreach (var node in lists)
            {
                if (node == null)
                    continue;
                heap.Insert(node);
            }

            if (heap.IsEmpty())
                return null;

            var head = heap.Pop();
            var prev = head;
            while (!heap.IsEmpty())
            {
                if (prev.next?.val <= heap.Peek().val)
                {
                    prev = prev.next;
                }
                else
                {
                    if (prev.next != null)
                        heap.Insert(prev.next);

                    prev.next = heap.Pop();
                    prev = prev.next;
                }
            }

            return head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class Heap
        {
            public List<ListNode> _heap;

            public Heap()
            {
                _heap = new List<ListNode>
                {
                    new ListNode(0)
                };
            }

            public void Insert(ListNode value)
            {
                _heap.Add(value);
                int currentIndex = _heap.Count - 1;
                while (currentIndex > 0)
                {
                    int parentIndex = currentIndex / 2;
                    if (_heap[parentIndex].val > _heap[currentIndex].val)
                    {
                        Swap(parentIndex, currentIndex);
                        currentIndex = parentIndex;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            public ListNode Pop()
            {
                int currentIndex = 1;
                var result = _heap[currentIndex];
                int lastIndex = _heap.Count - 1;
                _heap[currentIndex] = _heap[lastIndex];
                _heap.RemoveAt(lastIndex--);

                while (currentIndex < lastIndex)
                {
                    int leftChildIndex = currentIndex * 2;
                    int rightChildIndex = leftChildIndex + 1;
                    int childIndex = rightChildIndex <= lastIndex
                        && _heap[leftChildIndex].val > _heap[rightChildIndex].val ? rightChildIndex : leftChildIndex;

                    if (childIndex <= lastIndex && _heap[currentIndex].val > _heap[childIndex].val)
                    {
                        Swap(currentIndex, childIndex);
                        currentIndex = childIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                return result;
            }

            public ListNode Peek()
            {
                return _heap[1];
            }

            public bool IsEmpty()
            {
                return _heap.Count == 1;
            }

            private void Swap(int i, int j)
            {
                var temp = _heap[i];
                _heap[i] = _heap[j];
                _heap[j] = temp;
            }
        }
    }
}
