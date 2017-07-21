using AlfredoRevillaBairesdevChallenge.Implementations;
using System;

namespace AlfredoRevillaBairesdevChallenge
{
    public class Program
    {
        private static void Main(string[] args)
        {
            new Application(
                new FileBasedContactRepository("people.in", new StringLineToContactMapper()),
                new RankingByAdditionalOptionalConditionsMetLogic(
                    new FluentCollectionBase<Func<Contact, bool>>()
                    .Add(o => true),
                    new FluentCollectionBase<Func<Contact, bool>>()
                    .Add(o => true)),
                new WriteResultIdsToFileHandler("people.out"),
                new ApplicationErrorHandler()).Run();
        }
    }
}