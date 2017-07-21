using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlfredoRevillaBairesdevChallenge.Implementations.Tests
{
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

    public class LogicTests
    {
        [Fact]
        public void Contact_with_optional_condition_met_should_be_ranked_first()
        {
            //  arrange
            var lowRankedContacts = A.CollectionOfDummy<Contact>(10);
            var topRankedContacts = A.CollectionOfDummy<Contact>(2);
            foreach (var item in topRankedContacts)
            {
                item.Country = "asdsadsad";
            }
            var contacts = new List<Contact>();
            contacts.AddRange(lowRankedContacts);
            contacts.AddRange(topRankedContacts);
            var optionalConditions = new List<Func<Contact, bool>>();
            optionalConditions.Add(o => !string.IsNullOrEmpty(o.Country));
            var logic = new Logic(new ConditionCollection().Add(o => true), optionalConditions);

            //  act
            var result = logic.GetPotentialCustomers(contacts);

            //  assert
            result.Take(2).SequenceEqual(topRankedContacts).Should().BeTrue();
        }

        [Fact]
        public void No_conditions_should_return_empty_collection()
        {
            //  arrange
            var logic = new Logic(Enumerable.Empty<Func<Contact, bool>>(), Enumerable.Empty<Func<Contact, bool>>());
            var contacts = A.CollectionOfDummy<Contact>(new Random().Next(100));

            //  act
            var result = logic.GetPotentialCustomers(contacts);

            //  assert
            result.Should().BeEmpty();
        }
    }
}