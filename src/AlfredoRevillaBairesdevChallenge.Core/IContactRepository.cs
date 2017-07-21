using System.Collections.Generic;

namespace AlfredoRevillaBairesdevChallenge
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetCustomers();
    }
}