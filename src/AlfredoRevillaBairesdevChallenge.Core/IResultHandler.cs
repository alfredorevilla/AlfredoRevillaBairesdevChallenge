using System.Collections.Generic;

namespace AlfredoRevillaBairesdevChallenge
{
    public interface IResultHandler
    {
        void HandlePotentialCustomers(IEnumerable<Contact> enumerable);
    }
}