using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;

namespace AlfredoRevillaBairesdevChallenge.Tests
{
    public class FileBasedContactRepositoryTests
    {
        private FileBasedContactRepository _repository;

        [Fact]
        public void Ctor_and_GetCustomers_should_not_throw_if_file_exists()
        {
            this.Invoking((subject) =>
                        _repository = new FileBasedContactRepository("people.in", A.Fake<IStringToContactMapper>()))
                        .ShouldNotThrow();

            this.Invoking((subject) =>
                        _repository.GetCustomers())
                        .ShouldNotThrow();
        }

        [Fact]
        public void Ctor_should_throw_if_null_file_or_does_not_exists()
        {
            this.Invoking((subject) =>
                        _repository = new FileBasedContactRepository(Guid.NewGuid().ToString(), A.Fake<IStringToContactMapper>()))
                        .ShouldThrow<ArgumentException>();
        }
    }
}