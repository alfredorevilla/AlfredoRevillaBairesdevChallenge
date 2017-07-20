using AlfredoRevillaBairesdevChallengeConsole;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace AlfredoRevillaBairesdevChallenge.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Mapper mapper = new Mapper();
            var value = mapper.Read(File.ReadAllLines("people.in"));
            Console.WriteLine(value.Count(o => o.NumberOfConnections > 0));
            Console.WriteLine(value.Count(o => o.NumberOfRecommendations > 0));
        }
    }
}