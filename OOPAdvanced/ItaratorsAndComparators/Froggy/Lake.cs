using System;
using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private List<T> stones;

        public Lake(List<T> stones)
        {
            this.stones = stones;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return stones[i];
                }
            }
            for (int i = this.stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}