using FakeItEasy;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace AlfredoRevillaBairesdevChallenge.Implementations.Tests
{
    public class RankingByAdditionalOptionalConditionsMetLogicTests
    {
        [Fact]
        public void Contacts_with_optional_condition_met_should_be_ranked_first()
        {
            //  arrange
            var logic = new RankingByAdditionalOptionalConditionsMetLogic(new ConditionFluentCollection().Add(o => true), new ConditionFluentCollection().Add(o => !o.Country.IsNullOrEmpty()));
            var topRanked = A.CollectionOfDummy<Contact>(new Random(1).Next(100));
            topRanked.ForEach(o => o.Country = Guid.NewGuid().ToString());

            //  act
            var result = logic.GetPotentialCustomers(new FluentCollectionBase<Contact>(A.CollectionOfDummy<Contact>(new Random(1).Next(100))).AddRange(topRanked));

            //  assert
            result.Take(topRanked.Count).ShouldBeEquivalentTo(topRanked);
        }

        [Fact]
        public void No_conditions_should_return_empty_collection()
        {
            //  arrange
            var logic = new RankingByAdditionalOptionalConditionsMetLogic(Enumerable.Empty<Func<Contact, bool>>(), Enumerable.Empty<Func<Contact, bool>>());
            var contacts = A.CollectionOfDummy<Contact>(new Random().Next(100));

            //  act
            var result = logic.GetPotentialCustomers(contacts);

            //  assert
            result.Should().BeEmpty();
        }
    }
}