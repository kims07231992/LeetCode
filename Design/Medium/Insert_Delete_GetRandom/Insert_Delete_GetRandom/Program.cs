using System;
using System.Collections.Generic;
using System.Linq;

namespace Insert_Delete_GetRandom
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var randomizedSet = new RandomizedSet();
            randomizedSet.Insert(1); // true
            randomizedSet.Remove(2); // false
            randomizedSet.Insert(2); // true
            randomizedSet.GetRandom(); // 1
            randomizedSet.Remove(1); // true
            randomizedSet.Insert(2); // false
            randomizedSet.GetRandom(); // 2
        }

        public class RandomizedSet
        {
            private Dictionary<int, int> map;
            private List<int> elements;
            private Random random;

            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                map = new Dictionary<int, int>(); // Key: value, Value: index
                elements = new List<int>();
                random = new Random();
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (map.ContainsKey(val))
                    return false;

                elements.Add(val);
                map.Add(val, elements.Count() - 1);

                return true;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (!map.ContainsKey(val))
                    return false;

                var index = map[val];
                map.Remove(val);

                var lastIndex = elements.Count() - 1;
                if (index == lastIndex)
                    elements.RemoveAt(index);
                else
                {
                    // swap
                    var lastElement = elements[lastIndex];
                    elements[index] = lastElement;
                    elements.RemoveAt(lastIndex);
                    map[lastElement] = index;
                }

                return true;
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                var randomIndex = random.Next(0, elements.Count);
                return elements[randomIndex];
            }
        }
    }
}
