using AlfredoRevillaBairesdevChallenge.Implementations;
using System;
using System.Linq;

namespace AlfredoRevillaBairesdevChallenge
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var targetCountries = new[] { "peru", "argentina", "venezuela", "brazil" }; //etc

            new Application(
                new FileBasedContactRepository("people.in", new StringLineToContactMapper()),
                new RankingByAdditionalOptionalConditionsMetLogic(
                    //
                    //  condiciones requeridas
                    //
                    new FluentCollectionBase<Func<Contact, bool>>()
                    //  el país debe ser latinoamericano
                    .Add(o => targetCountries.Contains(o.Country, StringComparer.CurrentCultureIgnoreCase))
                    //  no debe tener rol
                    .Add(o => o.CurrentRole.IsNullOrEmpty()),

                    //
                    //  condiciones opcionales, a mas dadas más puntaje
                    //
                    new FluentCollectionBase<Func<Contact, bool>>()
                    .Add(o => true)
                    .Add(o => o.NumberOfConnections > 100)
                    .Add(o => o.NumberOfConnections > 200)
                    .Add(o => o.NumberOfConnections > 300)
                    .Add(o => o.NumberOfConnections > 400)
                    .Add(o => o.NumberOfConnections > 500)
                    .Add(o => o.NumberOfRecommendations > 100)
                    .Add(o => o.NumberOfRecommendations > 200)
                    .Add(o => o.NumberOfRecommendations > 300)
                    .Add(o => o.NumberOfRecommendations > 400)
                    .Add(o => o.NumberOfRecommendations > 500)),
                new WriteResultIdsToFileHandler("people.out"),
                new ApplicationErrorHandler()).Run();
        }
    }
}