using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace AlfredoRevillaBairesdevChallenge.Tests
{
    public class StringLineToContactMapperTests
    {
        private StringLineToContactMapper _mapper;

        public StringLineToContactMapperTests()
        {
            _mapper = new StringLineToContactMapper();
        }

        [Fact]
        public void Result_count_should_be_same_as_input_lines_count()
        {
            //  arrage
            var data = new[]{"573435640 | jean | harion | vice president | Dominica | Telecommunications | 0 | 0",
                 "337983069 | meredith | kopit - levien | chief revenue officer| United States | Publishing | 0 | 0"};

            //  act
            var result = _mapper.Map(data);

            //  assert
            result.Count().Should().Be(data.Count());
        }
    }
}