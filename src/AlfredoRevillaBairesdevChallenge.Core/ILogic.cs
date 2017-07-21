using System.Collections.Generic;

namespace AlfredoRevillaBairesdevChallenge
{
    public interface ILogic
    {
        IEnumerable<Contact> GetPotentialCustomers(IEnumerable<Contact> enumerable);
    }
}