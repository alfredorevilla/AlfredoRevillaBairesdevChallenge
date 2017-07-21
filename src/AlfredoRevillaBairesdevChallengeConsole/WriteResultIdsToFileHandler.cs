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
            File.WriteAllLines(_outputFilePathOrName, enumerable.Select(o => o.PersonId.ToString()), Encoding.Unicode);
        }
    }
}