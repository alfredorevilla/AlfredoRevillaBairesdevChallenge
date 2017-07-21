using System;
using System.Linq;
using System.Collections.Generic;

using System.Linq;
using AlfredoRevillaBairesdevChallenge.Implementations;

namespace AlfredoRevillaBairesdevChallenge
{
    public class ContactsManager
    {
        private IOrderedEnumerable<IGrouping<int, IElementRanking<IElementRankingManager<Contact>>>> groupedByRankingManagers;
        private IEnumerable<IContactRankingManager> managers;

        public ContactsManager(IEnumerable<IContactRankingManager> managers)
        {
            this.groupedByRankingManagers = new RankByOrder().GetRankings(managers).GroupBy(o => o.Ranking).OrderBy(o => o.Key);
            this.managers = managers;




        }


        public IEnumerable<Contact> GetPotentialCustomers(IEnumerable<Contact> contacts)
        {
            string[] countries = new[] { "" };
            var roles = new[] { "" };
            var industries = new[] { "" };
            contacts.Where(o => countries.Contains(o.Country));
        }
    }
}