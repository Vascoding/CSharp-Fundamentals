using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomList
{
    public class Sorter<T> where T : IComparable<T>
    {
        public static List<T> Sort(List<T> customList)
        {
            var ordered = customList.OrderBy(x => x).ToList();
            return ordered;
        }
    }

}