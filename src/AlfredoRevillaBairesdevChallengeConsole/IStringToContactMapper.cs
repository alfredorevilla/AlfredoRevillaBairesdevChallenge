using System.Collections.Generic;

namespace AlfredoRevillaBairesdevChallenge
{
    public interface IStringToContactMapper
    {
        Contact Map(string line);

        IEnumerable<Contact> Map(string[] lines);
    }
}