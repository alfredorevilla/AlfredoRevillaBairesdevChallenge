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

        public IEnumerable<Contact> GetPotentialCustomers(IEnumerable<Contact> collection)
        {
            foreach (var item in requiredConditions)
            {
                collection = collection.Where(item);
            }
            var points = collection.ToDictionary(o => o, o => 1);
            foreach (var item in optionalConditions)
            {
                collection.Where(o => true || item(o)).Select(o => points[o]++);
            }
            return collection.OrderByDescending(o => points[o]);
        }
    }
}
