using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AlfredoRevillaBairesdevChallenge.Implementations
{
    public class RankingByAdditionalOptionalConditionsMetLogic : ILogic
    {
        private IEnumerable<Func<Contact, bool>> _optionalConditions;
        private IEnumerable<Func<Contact, bool>> _requiredConditions;

        public RankingByAdditionalOptionalConditionsMetLogic(IEnumerable<Func<Contact, bool>> requiredConditions, IEnumerable<Func<Contact, bool>> optionalConditions)
        {
            this._requiredConditions = requiredConditions;
            this._optionalConditions = optionalConditions;
        }

        public IEnumerable<Contact> GetPotentialCustomers(IEnumerable<Contact> collection)
        {
            var value = collection;
            foreach (var item in _requiredConditions)
            {
                value = value.Where(item);
            }
            var points = collection.ToDictionary(o => o, o => 1);
            foreach (var item in _optionalConditions)
            {
                foreach (var item2 in value)
                {
                    if (item(item2))
                    {
                        points[item2]++;
                    }
                }
            }
            return value.OrderByDescending(o => points[o]);
        }
    }
}