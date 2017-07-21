using System;
using System.Collections;
using System.Collections.Generic;

namespace AlfredoRevillaBairesdevChallenge
{
    //  todo: move to core?
    public class ConditionCollection : IEnumerable<Func<Contact, bool>>
    {
        private List<Func<Contact, bool>> _list;

        public ConditionCollection()
        {
            this._list = new List<Func<Contact, bool>>();
        }

        public ConditionCollection Add(Func<Contact, bool> condition)
        {
            if (_list.Contains(condition))
            {
                throw new ArgumentException(nameof(condition));
            }
            _list.Add(condition);
            return this;
        }

        public IEnumerator<Func<Contact, bool>> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this._list).GetEnumerator();
        }
    }
}