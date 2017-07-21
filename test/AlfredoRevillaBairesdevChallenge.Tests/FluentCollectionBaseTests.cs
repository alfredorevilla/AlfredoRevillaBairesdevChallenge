using FluentAssertions;
using FakeItEasy;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlfredoRevillaBairesdevChallenge.Tests
{
    public class FluentCollectionBaseTests
    {
        private FluentCollectionBase<int> _collection;

        [Fact]
        public void AddRangeTest()
        {
            //  arrange
            _collection = new FluentCollectionBase<int>();
            var range = A.CollectionOfDummy<int>(new Random().Next(100));

            //  act
            _collection.AddRange(range);

            //  assert
            _collection.ShouldBeEquivalentTo(range);
        }

        [Fact]
        public void AddTest()
        {
            //  arrange
            _collection = new FluentCollectionBase<int>();
            var number = new Random().Next(100);

            //  act
            _collection.Add(number);

            //  assert
            _collection.Count().Should().Be(1);
            _collection.Single().Should().Be(number);
        }
    }
}