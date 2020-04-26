using System.Collections.Generic;

namespace Moving_Average_from_Data_Stream
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var m = new MovingAverage(3);
            m.Next(1); // = 1
            m.Next(10); // = (1 + 10) / 2
            m.Next(3); // = (1 + 10 + 3) / 3
            m.Next(5); // = (10 + 3 + 5) / 3
        }

        public class MovingAverage
        {
            private Queue<int> _queue = new Queue<int>();
            private int _size;
            private int _sum;

            /** Initialize your data structure here. */
            public MovingAverage(int size)
            {
                _size = size;
            }

            public double Next(int val)
            {
                if (_queue.Count >= _size) // exceeding its size, release previous element
                {
                    var item = _queue.Dequeue();
                    _sum -= item;
                }

                // sliding
                _queue.Enqueue(val);
                _sum += val;

                // return average
                return (double)_sum / _queue.Count;
            }
        }
    }
}
