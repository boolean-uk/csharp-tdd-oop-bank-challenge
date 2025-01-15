using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Exceptions
{
    public class InsufficientFundsException : ArgumentException
    {
        public InsufficientFundsException() { }

        public InsufficientFundsException(string? message) : base(message) { }

        public InsufficientFundsException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
