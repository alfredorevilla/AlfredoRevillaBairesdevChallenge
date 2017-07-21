using System;

namespace AlfredoRevillaBairesdevChallenge
{
    //  todo: develop
    public class ValidatableArgument
    {
        public ValidatableArgument(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; }

        public object Value { get; }
    }
}