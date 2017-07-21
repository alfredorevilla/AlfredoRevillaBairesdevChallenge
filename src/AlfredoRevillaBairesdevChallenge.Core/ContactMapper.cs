using System;

using System.Collections.Generic;
using System.Text;

namespace AlfredoRevillaBairesdevChallenge
{
    public class ContactMapper
    {
        public Contact Map(string line)
        {
            var i = 0;
            var values = line.Split('|');
            return new Contact
            {
                PersonId = long.Parse(values[i++]),
                Name = values[i++],
                LastName = values[i++],
                CurrentRole = values[i++],
                Country = values[i++],
                Industry = values[i++],
                NumberOfRecommendations = int.Parse(values[i++]),
                NumberOfConnections = int.Parse(values[i++])
            };
        }

        public IEnumerable<Contact> Map(string[] lines)
        {
            foreach (var item in lines)
            {
                yield return Map(item);
            }
        }
    }
}