using System;
using System.Collections;
using System.Collections.Generic;

namespace AlfredoRevillaBairesdevChallenge
{
    public class FluentCollectionBase<TElement> : IEnumerable<TElement>
    {
        private List<TElement> _list;

        public FluentCollectionBase(IEnumerable<TElement> collection)
        {
            _list = new List<TElement>(collection);
        }

        public FluentCollectionBase()
        {
            _list = new List<TElement>();
        }

        public virtual FluentCollectionBase<TElement> Add(TElement element)
        {
            _list.Add(element);
            return this;
        }

        public virtual FluentCollectionBase<TElement> AddRange(IEnumerable<TElement> collection)
        {
            _list.AddRange(collection);
            return this;
        }

        public virtual FluentCollectionBase<TElement> ForEach(Action<TElement> action)
        {
            foreach (var item in this)
            {
                action(item);
            }
            return this;
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this._list).GetEnumerator();
        }
    }
}