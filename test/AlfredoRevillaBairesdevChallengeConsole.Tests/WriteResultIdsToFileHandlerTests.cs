using FluentAssertions;
using FakeItEasy;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace AlfredoRevillaBairesdevChallenge.Tests
{
    public class WriteResultIdsToFileHandlerTests
    {
        private const string outputFilePath = "dummy_output_file.dummy_extension";
        private WriteResultIdsToFileHandler _handler;
        private Random _random;

        public WriteResultIdsToFileHandlerTests()
        {
            _random = new Random();
        }

        [Fact]
        public void Output_file_should_be_written()
        {
            //  arrange
            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }
            var contacts = A.CollectionOfDummy<Contact>(_random.Next(100));
            _handler = new WriteResultIdsToFileHandler(outputFilePath);

            //  act
            _handler.HandlePotentialCustomers(contacts);

            //  assert
            File.Exists(outputFilePath).Should().BeTrue();
        }

        [Fact]
        public void Should_write_contacts_ids()
        {
            //  arrange
            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }
            var contacts = A.CollectionOfDummy<Contact>(_random.Next(100));
            _handler = new WriteResultIdsToFileHandler(outputFilePath);

            //  act
            _handler.HandlePotentialCustomers(contacts);
            var ids = File.ReadAllLines(outputFilePath).Select(o => long.Parse(o));

            //  assert
            ids.ShouldBeEquivalentTo(contacts.Select(o => o.PersonId));
        }
    }
}