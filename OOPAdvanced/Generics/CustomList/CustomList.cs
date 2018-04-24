using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomList
{
    public class CustomList<T> 
        where T : IComparable<T>
    {
        private List<T> elements;

        public CustomList()
        {
            this.Elements = new List<T>();
        }

        public List<T> Elements
        {
            get { return this.elements; }
            set { this.elements = value; }
        }
        public void Add(T element)
        {
            this.Elements.Add(element);
        }

        public T Remove(int index)
        {
            var element = this.elements[index];

            elements.RemoveAt(index);
            return element;
        }

        public bool Contains(T element)
        {
            if (this.elements.Contains(element))
            {
                return true;
            }
            return false;
        }

        public void Swap(int a, int b)
        {
            var box = this.elements[a];
            this.elements[a] = this.elements[b];
            this.elements[b] = box;
        }

        public int CountGreaterThan(T elementInput)
        {
            var count = 0;
            foreach (var element in elements)
            {
                if (element.CompareTo(elementInput) > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public T Max()
        {
            return elements.Max();
        }
        public T Min()
        {
            return elements.Min();
        }

        
        public override string ToString()
        {
            return $"{string.Join(Environment.NewLine, elements)}";
        }
    }
}