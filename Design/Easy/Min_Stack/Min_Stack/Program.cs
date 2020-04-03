using System;
using System.Collections;
using System.Collections.Generic;

namespace Min_Stack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            var minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            minStack.GetMin(); // Returns -3.
            minStack.Pop();
            minStack.Top(); // Returns 0.
            minStack.GetMin(); // Returns -2.
        }

        public class MinStack
        {
            private int _min = int.MaxValue;
            private Stack<int> _stack = new Stack<int>();

            public MinStack()
            {

            }

            public void Push(int x)
            {
                // only push the old minimum value when the current 
                // minimum value changes after pushing the new value x
                if (x <= _min)
                {
                    _stack.Push(_min);
                    _min = x;
                }
                _stack.Push(x);
            }

            public void Pop()
            {
                // if pop operation could result in the changing of the current minimum value, 
                // pop twice and change the current minimum value to the last minimum value.
                if (_stack.Pop() == _min)
                    _min = _stack.Pop();
            }

            public int Top()
            {
                return _stack.Peek();
            }

            public int GetMin()
            {
                return _min;
            }
        }
    }
}
