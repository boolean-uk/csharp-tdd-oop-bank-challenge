using Boolean.CSharp.Main.extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.src.transaction
{
    public interface ITransaction
    {
        public double OldBalance { get; }
        public double NewBalance { get; }
        public double Amount { get; }
        public Status Status { get; }
        public TransactionType Type { get; }
    }
}
