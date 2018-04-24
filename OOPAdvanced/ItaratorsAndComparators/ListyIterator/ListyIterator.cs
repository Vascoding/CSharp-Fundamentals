using System;
using System.Collections;
using System.Collections.Generic;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerator<T>, IEnumerable<T>
    {
        private int currentIndex;
        private List<T> elements;

        public ListyIterator()
        {
            this.currentIndex = 0;
            this.elements = new List<T>();
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.elements.Count - 1 > this.currentIndex)
            {
                this.currentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.elements.Count - 1 > this.currentIndex)
            {
                return true;
            }

            return false;
        }
        public void Reset()
        {
           // this.currentIndex = -1;
        }

        public T Current { get { return this.elements[currentIndex]; } }

        public string Print()
        {
            if (this.elements.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            return $"{this.elements[currentIndex]}";

        }

        public void Create(params T[] elements)
        {
            var e = new List<T>();
            if (elements.Length == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                foreach (var element in elements)
                {
                    e.Add(element);
                }
            }
            this.elements = e;
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Count; i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}