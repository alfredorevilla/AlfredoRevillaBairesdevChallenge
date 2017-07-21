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
        private WriteResultIdsToFileHandler _handler;

        [Fact]
        public void Output_file_should_be_written()
        {
            //  arrange
            var outputFilePath = "dummy_output_file.dummy_extension";
            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }
            var contacts = A.CollectionOfDummy<Contact>(new Random(1).Next(100));
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
            var outputFilePath = "dummy_output_file.dummy_extension";
            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }
            var contacts = A.CollectionOfDummy<Contact>(new Random(1).Next(100));
            _handler = new WriteResultIdsToFileHandler(outputFilePath);

            //  act
            _handler.HandlePotentialCustomers(contacts);
            var ids = File.ReadAllLines(outputFilePath).Select(o => long.Parse(o));

            //  assert
            ids.ShouldBeEquivalentTo(contacts.Select(o => o.PersonId));
        }
    }
}