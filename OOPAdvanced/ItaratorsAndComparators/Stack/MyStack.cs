using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public MyStack()
        {
            this.elements = new List<T>();
        }
        public void Push(params T[] items)
        {
            var stack = new List<T>();
            for (int i = items.Length - 1; i >= 0; i--)
            {
                stack.Add(items[i]);
            }
            for (int i = 0; i < this.elements.Count; i++)
            {
                stack.Add(this.elements[i]);
            }
            this.elements = stack;
        }

        public T Pop()
        {
            if (this.elements.Count == 0)
            {
                throw new ArgumentException("No elements");
            }
            var e = this.elements[0];
            this.elements.Remove(elements[0]);
            return e;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < elements.Count; j++)
                {
                    yield return this.elements[j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}