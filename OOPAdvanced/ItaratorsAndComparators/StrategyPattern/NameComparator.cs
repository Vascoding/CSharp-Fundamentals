using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class NameComparator : IComparer<Person>
    {
        private SortedSet<Person> people;
        
        public int Compare(Person x, Person y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);
            if (result == 0)
            {
                result = string.Compare(x.Name[0].ToString(), y.Name[0].ToString(), StringComparison.OrdinalIgnoreCase);
            }
            return result;
        }
    }
}