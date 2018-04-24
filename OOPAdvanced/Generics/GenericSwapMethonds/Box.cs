using System;

namespace GenericSwapMethonds
{
    public class Box<T>
        where T : IComparable<T>
    {
        private T type;

        public Box(T type)
        {
            this.type = type;
        }

        public int Compare(T command)
        {
            return type.CompareTo(command);
        }

        public override string ToString()
        {
            return $"{this.type.GetType().FullName}: {this.type}";
        }
    }
}