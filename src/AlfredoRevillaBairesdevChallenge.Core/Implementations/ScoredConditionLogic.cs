using System.Collections.Generic;
using System.Linq;

namespace AlfredoRevillaBairesdevChallenge.Implementations
{
    public class ScoredConditionLogic : ILogic
    {
        private IEnumerable<ScoredCondition> _conditions;

        public ScoredConditionLogic(IEnumerable<ScoredCondition> conditions)
        {
            this._conditions = conditions;
        }

        public IEnumerable<Contact> GetPotentialCustomers(IEnumerable<Contact> enumerable)
        {
            var points = enumerable.ToDictionary(o => o.PersonId, o => 0);
            if (!enumerable.Any() || !_conditions.Any())
            {
                return enumerable;
            }
            foreach (var item in _conditions)
            {
                foreach (var element in enumerable)
                {
                    points[element.PersonId] += item(element);
                }
            }
            return enumerable.OrderByDescending(o => points[o.PersonId]);
        }
    }
}