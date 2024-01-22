using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Transactions
{
    public interface ITransaction
    {
        public Guid Id { get; }
        public TransactionType Type { get; }
        public TransactionStatus Status { get; }
        public DateTime Date { get; }
        public double Amount { get; }
        public double NewBalance { get; }
        public double OldBalance { get; }
    }
}
