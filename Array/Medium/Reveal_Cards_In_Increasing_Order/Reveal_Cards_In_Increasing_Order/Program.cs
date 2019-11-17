using System;
using System.Collections.Generic;
using System.Linq;

namespace Reveal_Cards_In_Increasing_Order
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            int[] deck = { 17, 13, 11, 2, 3, 5, 7 };
            int[] output = DeckRevealedIncreasing(deck);
        }

        /// <summary>
        /// Time Complexity: O(NlogN + 2N) => O(NlogN) where N is the length of deck
        /// Space Complexity => O(N)
        /// </summary>
        private static int[] DeckRevealedIncreasing(int[] deck)
        {
            var n = deck.Length;
            var output = new int[n];
            var queue = new Queue<int>(Enumerable.Range(0, n).ToArray()); // N

            Array.Sort(deck); // Quicksort NlogN
            for (int i = 0; i < n; i++) // N
            {
                output[queue.Dequeue()] = deck[i];
                if (queue.Count > 0)
                    queue.Enqueue(queue.Dequeue());
            }

            return output;
        }
    }
}
