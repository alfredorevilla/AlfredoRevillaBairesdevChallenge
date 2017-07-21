using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlfredoRevillaBairesdevChallenge
{
    public class ArgumentValidator
    {
        public static void ValidateNotNullOrEmpty<T>(IEnumerable<T> collection, string argumentName)
        {
            if (collection.IsNullOrEmpty())
            {
                throw new ArgumentException(argumentName);
            }
        }
    }
}