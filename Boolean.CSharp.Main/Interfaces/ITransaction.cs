using Boolean.CSharp.Main.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface ITransaction
    {
        public Guid Id { get; }
        public TransactionType Type { get; }
        public TransactionStatus Status { get; set; }
        public DateTime Date { get; }
        public decimal Amount { get; set; }
        public decimal NewBalance { get; set; }
        public decimal OldBalance { get; set; }
    }
}
