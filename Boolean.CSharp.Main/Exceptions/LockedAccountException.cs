using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Exceptions
{
    public class LockedAccountException : Exception
    {
        public LockedAccountException() { }

        public LockedAccountException(string? message) : base(message) { }

        public LockedAccountException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
