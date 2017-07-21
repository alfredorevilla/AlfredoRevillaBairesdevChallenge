using AlfredoRevillaBairesdevChallenge.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlfredoRevillaBairesdevChallenge
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //  todo: move all these conditions to another class/code file
            var targetCountries = new[] { "peru", "argentina", "venezuela", "brazil" }; //etc
            var perNumberOfConnectionConditions = new List<Func<Contact, bool>>();
            for (int i = 0; i < 10; i += 10)
            {
                var i2 = i;
                perNumberOfConnectionConditions.Add(o => o.NumberOfConnections > i2);
            }
            var perRecommendatiosConditions = new List<Func<Contact, bool>>();
            for (int i = 0; i < 10; i++)
            {
                var i2 = i;
                perRecommendatiosConditions.Add(o => o.NumberOfRecommendations > i2);
            }

            //  default to 100 ids
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
                    //  condiciones opcionales: a mas cumplidas más puntaje
                    //
                    new FluentCollectionBase<Func<Contact, bool>>()
                    //  1 punto por cada 10 conexiones que tenga
                    .AddRange(perNumberOfConnectionConditions)
                    //  1 punto por cada recomendacione que tenga
                    .AddRange(perRecommendatiosConditions)),
                new WriteResultIdsToFileHandler("people.out"),
                new ApplicationErrorHandler()).Run();
        }
    }
}