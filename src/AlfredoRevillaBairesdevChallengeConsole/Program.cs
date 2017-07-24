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

            //  defaults to 100 ids
            new Application(
                new FileBasedContactRepository("people.in", new StringLineToContactMapper()),
                new ScoredConditionLogic(

                    //
                    //  condiciones, todas retornan 0 o más puntos, ahora el control es mayor
                    //
                    new FluentCollectionBase<ScoredCondition>()
                    //  para que prorice contactos latinoamericanos le ponemos un puntaje muy alto a tal condición,
                    //  ahora bien si se desea excluir todo pais no lo sea podemos hacerlo previamente en el repository
                    .Add(o => targetCountries.Contains(o.Country, StringComparer.CurrentCultureIgnoreCase) ? 1000 : 0)
                    //  no debe tener rol
                    .Add(o => o.CurrentRole.IsNullOrEmpty() ? 1 : 0)
                    //  1 punto por cada 10 conexiones que tenga
                    .Add(o => (int)Math.Floor((decimal)(o.NumberOfConnections / 10)))
                    //  1 punto por cada recomendacione que tenga
                    .Add(o => o.NumberOfRecommendations)),
                new WriteResultIdsToFileHandler("people.out"),
                new ApplicationErrorHandler()).Run();
        }
    }
}