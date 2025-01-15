using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Exceptions
{
    public class LimitExceededException : Exception
    {
        public LimitExceededException() { }

        public LimitExceededException(string? message) : base(message) { }

        public LimitExceededException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
