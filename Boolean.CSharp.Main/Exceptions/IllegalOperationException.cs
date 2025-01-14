using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Exceptions
{
    public class IllegalOperationException : ArgumentException
    {
        public IllegalOperationException() { }

        public IllegalOperationException(string? message) : base(message) { }

        public IllegalOperationException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
