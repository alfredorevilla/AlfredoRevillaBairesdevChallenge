using AlfredoRevillaBairesdevChallenge.Implementations;
using System;

namespace AlfredoRevillaBairesdevChallenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Application(
                new FileBasedContactRepository("people.in", new StringLineToContactMapper()),
                new RankingByAdditionalOptionalConditionsMetLogic(
                    new FluentCollectionBase<Func<Contact, bool>>()
                    .Add(o => true)
                    .Add(o => false),
                    new FluentCollectionBase<Func<Contact, bool>>()
                    .Add(o => true)
                    .Add(o => false)),
                new WriteResultIdsToFileHandler("people.out"),
                new ApplicationErrorHandler()).Run();
        }
    }
}