using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlfredoRevillaBairesdevChallenge.Implementations.Tests
{
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
            optionalConditions.Add(o => string.IsNullOrEmpty(o.Country));
            var logic = new Logic(Enumerable.Empty<Func<Contact, bool>>(), optionalConditions);

            //  act
            var result = logic.GetPotentialCustomers(contacts);

            //  assert
            result.Take(2).SequenceEqual(topRankedContacts).Should().BeTrue();
        }

        [Fact]
        public void No_conditions_should_return_whole_collection()
        {
            var logic = new Logic(Enumerable.Empty<Func<Contact, bool>>(), Enumerable.Empty<Func<Contact, bool>>());

            var contacts = A.CollectionOfDummy<Contact>(100);
            logic.GetPotentialCustomers(contacts).SequenceEqual(contacts).Should().BeTrue();
        }
    }
}