using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AlfredoRevillaBairesdevChallenge.Implementations
{
    public class Logic : ILogic
    {
        private IEnumerable<Func<Contact, bool>> requiredConditions;
        private IEnumerable<Func<Contact, bool>> optionalConditions;

        public Logic(IEnumerable<Func<Contact, bool>> requiredConditions, IEnumerable<Func<Contact, bool>> optionalConditions)
        {
            this.requiredConditions = requiredConditions;
            this.optionalConditions = optionalConditions;
        }

        public IEnumerable<Contact> GetPotentialCustomers(IEnumerable<Contact> enumerable)
        {
            foreach (var item in requiredConditions)
            {
                enumerable = enumerable.Where(item);
            }
            foreach (var item in optionalConditions)
            {
                enumerable = enumerable.Where(o => true || item(o));
            }
            return enumerable.Select(o => new { Contact = o, NumberOfRelations = o.NumberOfConnections + o.NumberOfRecommendations }).OrderByDescending(o => o.NumberOfRelations).Select(o => enumerable.Single(p => p == o.Contact));
        }
    }
}
