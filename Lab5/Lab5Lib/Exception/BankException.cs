using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Lib
{
    [Serializable()]
    public class BankException : System.Exception
    {
        public string Value { get; }
        public BankException() : base() { }
        public BankException(string message) : base(message) { }
        public BankException(string message, System.Exception inner) : base(message, inner) { }
        public BankException(string message, string val) : base(message)
        {
            Value = val;
        }

        protected BankException(System.Runtime.Serialization.SerializationInfo info,
       System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
