using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlfredoRevillaBairesdevChallenge
{
    internal class FileBasedContactRepository : IContactRepository
    {
        private string _filePath;
        private IStringToContactMapper _stringToContactMapper;

        public FileBasedContactRepository(string filePath, IStringToContactMapper stringToContactMapper)
        {
            if (stringToContactMapper == null)
            {
                throw new ArgumentNullException(nameof(stringToContactMapper));
            }
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException(filePath);
                }
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(filePath));
            }

            this._filePath = filePath;
            this._stringToContactMapper = stringToContactMapper;
        }

        public IEnumerable<Contact> GetCustomers()
        {
            var value = File.ReadAllLines(this._filePath);
            return this._stringToContactMapper.Map(value);
        }
    }
}