using System;
using System.Collections.Generic;
using System.Linq;

namespace InfernoInfinity
{
    abstract class Builder<T, TDerived> where TDerived : class
    {
        private T _item;

        public T Item
        {
            get { return this._item; }
            protected set
            {
                _item = value;
            } 
            }

        public TDerived Attach(T item)
        {
            _item = item;
            return this as TDerived;
        }

        public TDerived Detach()
        {
            _item = default(T);

            return this as TDerived;
        }

        public TDerived ChangeWith(ICollection<T> collection, Func<T, bool> predicate)
        {

            if (predicate(Item))
                return this as TDerived; // builder has the current predicate already attached

            var item = collection.FirstOrDefault(predicate);

            if (item == null)
                throw new ArgumentException();

            _item = item;

            return this as TDerived;
        }
    }
}