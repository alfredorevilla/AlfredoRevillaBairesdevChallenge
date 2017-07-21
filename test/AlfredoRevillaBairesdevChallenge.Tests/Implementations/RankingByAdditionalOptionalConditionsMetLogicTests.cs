using FakeItEasy;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace AlfredoRevillaBairesdevChallenge.Implementations.Tests
{
    public class RankingByAdditionalOptionalConditionsMetLogicTests
    {
        private RankingByAdditionalOptionalConditionsMetLogic _logic;

        private Random _random;

        public RankingByAdditionalOptionalConditionsMetLogicTests()
        {
            _random = new Random();
        }

        [Fact]
        public void Contacts_with_optional_condition_met_should_be_ranked_first()
        {
            //  arrange
            _logic = new RankingByAdditionalOptionalConditionsMetLogic(
                //  required
                new ConditionFluentCollection().Add(o => true),
                //  optional
                new ConditionFluentCollection().Add(o => !o.Country.IsNullOrEmpty()));
            var topRanked = A.CollectionOfDummy<Contact>(_random.Next(100));
            topRanked.ForEach(o => o.Country = Guid.NewGuid().ToString());

            //  act
            var result = _logic.GetPotentialCustomers(new FluentCollectionBase<Contact>(A.CollectionOfDummy<Contact>(_random.Next(100))).AddRange(topRanked));

            //  assert
            result.Take(topRanked.Count).ShouldBeEquivalentTo(topRanked);
        }

        [Fact]
        public void Contacts_with_optional_condition_met_should_be_ranked_first_2()
        {
            //  arrange
            _logic = new RankingByAdditionalOptionalConditionsMetLogic(new ConditionFluentCollection().Add(o => true), new ConditionFluentCollection().Add(o => !o.Country.IsNullOrEmpty()));
            var topRanked = A.CollectionOfDummy<Contact>(_random.Next(100));
            topRanked.ForEach(o => o.Country = Guid.NewGuid().ToString());

            //  act
            var result = _logic.GetPotentialCustomers(new FluentCollectionBase<Contact>(A.CollectionOfDummy<Contact>(_random.Next(100))).AddRange(topRanked));

            //  assert
            result.Take(topRanked.Count).ShouldBeEquivalentTo(topRanked);
        }

        [Fact]
        public void Result_count_should_be_same_as_matched_contacts_1()
        {
            //  arrange
            _logic = new RankingByAdditionalOptionalConditionsMetLogic(
                new FluentCollectionBase<Func<Contact, bool>>().Add(o => o.NumberOfConnections > 0),
                Enumerable.Empty<Func<Contact, bool>>());
            var contacts = new FluentCollectionBase<Contact>(A.CollectionOfDummy<Contact>(_random.Next(100)))
                .Add(new Contact
                {
                    PersonId = -1,
                    NumberOfConnections = 500
                });

            //  act
            var result = _logic.GetPotentialCustomers(contacts);

            //  assert
            result.Count().Should().Be(1);
            result.Single().PersonId.Should().Be(-1);
        }

        [Fact]
        public void Result_count_should_be_same_as_matched_contacts_2()
        {
            //  arrange
            var matchingContacts = new FluentCollectionBase<Contact>(A.CollectionOfDummy<Contact>(_random.Next(100)));
            matchingContacts.ForEach(o => o.NumberOfRecommendations = _random.Next(100, 200));
            var contacts = new FluentCollectionBase<Contact>(A.CollectionOfDummy<Contact>(_random.Next(100))).AddRange(matchingContacts);
            _logic = new RankingByAdditionalOptionalConditionsMetLogic(
                new FluentCollectionBase<Func<Contact, bool>>()
                .Add(o => o.NumberOfRecommendations >= 100)
                .Add(o => o.NumberOfRecommendations <= 200),
                Enumerable.Empty<Func<Contact, bool>>());

            //  act
            var result = _logic.GetPotentialCustomers(contacts);

            //  assert
            result.Count().Should().Be(matchingContacts.Count());
        }
    }
}