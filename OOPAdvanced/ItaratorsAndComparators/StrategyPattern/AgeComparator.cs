using System.Collections.Generic;

namespace StrategyPattern
{
    public class AgeComparator : IComparer<Person>
    {
        private SortedSet<Person> people;
      
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}