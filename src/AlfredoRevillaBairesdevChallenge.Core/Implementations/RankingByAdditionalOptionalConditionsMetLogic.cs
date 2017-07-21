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
            var value = Enumerable.Empty<Contact>();
            if (_requiredConditions.Any())
            {
                value = collection.Where(_requiredConditions.First());
                foreach (var item in _requiredConditions.Skip(1))
                {
                    value = value.Where(item);
                }
            }
            else
            {
                return value;
            }
            var points = value.ToDictionary(o => o.PersonId, o => 1);
            foreach (var item in _optionalConditions)
            {
                foreach (var item2 in value)
                {
                    if (item(item2))
                    {
                        points[item2.PersonId]++;
                    }
                }
            }
            return value.OrderByDescending(o => points[o.PersonId]);
        }
    }
}