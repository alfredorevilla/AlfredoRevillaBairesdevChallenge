using AlfredoRevillaBairesdevChallenge.Implementations;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace AlfredoRevillaBairesdevChallenge.Tests.Implementations
{
    public class ScoredConditionLogicTests
    {
        private ScoredConditionLogic _logic;
        private Random _random;

        public ScoredConditionLogicTests()
        {
            _random = new Random();
        }

        [Fact]
        public void Top_ranked_contact_should_be_listed_first()
        {
            _logic = new ScoredConditionLogic(new FluentCollectionBase<ScoredCondition>().Add(o =>
            !o.Name.IsNullOrEmpty() ? 1 : 0));

            var lonelyName = Guid.NewGuid().ToString();

            var id = 0;
            var result = _logic.GetPotentialCustomers(
                new FluentCollectionBase<Contact>(
                    A.CollectionOfFake<Contact>(_random.Next(1, 100)))
                    .ForEach(o => o.PersonId = id++)
                    .Add(new Contact
                    {
                        PersonId = id++,
                        Name = lonelyName
                    })
            .AddRange(new FluentCollectionBase<Contact>(A.CollectionOfDummy<Contact>(_random.Next(1, 100)))
            .ForEach(o => o.PersonId = id++)));

            result.First().Name.Should().Be(lonelyName);
        }
    }
}