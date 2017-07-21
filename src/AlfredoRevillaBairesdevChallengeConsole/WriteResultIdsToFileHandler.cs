using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlfredoRevillaBairesdevChallenge
{
    public class WriteResultIdsToFileHandler : IResultHandler
    {
        private string _outputFilePathOrName;

        public WriteResultIdsToFileHandler(string outputFilePathOrName)
        {
            this._outputFilePathOrName = outputFilePathOrName;
        }

        public void HandlePotentialCustomers(IEnumerable<Contact> enumerable)
        {
            if (!enumerable.Any())
            {
                ConsoleHelper.WriteRedLines("No hay resultados que guardar", "");
            }
            else
            {
                File.WriteAllLines(_outputFilePathOrName, enumerable.Select(o => o.PersonId.ToString()), Encoding.Unicode);
                ConsoleHelper.WriteYellowLines($"Se escribió el archivo {_outputFilePathOrName} con los {enumerable.Count()} ids resultantes", "");
            }
        }
    }
}