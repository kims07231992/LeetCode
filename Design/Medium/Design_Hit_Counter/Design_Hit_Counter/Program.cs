using System;
using System.Collections.Generic;

namespace Design_Hit_Counter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var counter = new QueueHitCounter();
            // hit at timestamp 1.
            counter.hit(1);
            // hit at timestamp 2.
            counter.hit(2);
            // hit at timestamp 3.
            counter.hit(3);
            // get hits at timestamp 4, should return 3.
            Console.WriteLine(counter.getHits(4));
            // hit at timestamp 300.
            counter.hit(300);
            // get hits at timestamp 300, should return 4.
            Console.WriteLine(counter.getHits(300));
            // get hits at timestamp 301, should return 3.
            Console.WriteLine(counter.getHits(301));
        }

        public class QueueHitCounter
        {
            private readonly int _timeRange = 300;
            private Queue<int> _hits;

            /** Initialize your data structure here. */
            public QueueHitCounter()
            {
                _hits = new Queue<int>();
            }

            /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). 
            /// Time Complexity: O(1)
            /// Space Complexity: O(N) where N is number of timestamp
            */
            public void Hit(int timestamp)
            {
                _hits.Enqueue(timestamp);
            }

            /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). 
            /// Time Complexity: O(N) where N is number of timestamp
            /// Space Complexity: O(N)
            */
            public int GetHits(int timestamp)
            {
                while (_hits.Count > 0 && _hits.Peek() <= timestamp - _timeRange)
                {
                    _hits.Dequeue();
                }

                return _hits.Count;
            }
        }

        public class ArrayHitCounter
        {
            private readonly int _timeRange = 300;
            private int[] _timespans;
            private int[] _hits;

            /** Initialize your data structure here. */
            public ArrayHitCounter()
            {
                _timespans = new int[_timeRange];
                _hits = new int[_timeRange];
            }

            /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). 
            /// Time Complexity: O(1)
            /// Space Complexity: O(N) where N is size of time range
            */
            public void hit(int timestamp)
            {
                int i = timestamp % _timeRange;
                if (_timespans[i] != timestamp)
                {
                    _timespans[i] = timestamp;
                    _hits[i] = 1;
                }
                else
                {
                    _hits[i]++;
                }
            }

            /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). 
            /// Time Complexity: O(N) where N is range of time
            /// Space Complexity: O(N)
            */
            public int getHits(int timestamp)
            {
                int result = 0;
                for (int i = 0; i < _hits.Length; i++)
                {
                    if (timestamp - _timespans[i] < _timeRange)
                    {
                        result += _hits[i];
                    }
                }

                return result;
            }
        }
    }
}