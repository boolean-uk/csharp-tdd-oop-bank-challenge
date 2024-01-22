using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface ITransaction
    {
        public int Id { get; set; }
        public DateTime Date { get; }
        public TransactionStatus Status { get; set; }
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
        public double NewBalance { get; set; }
        public double OldBalance { get; set; }

    }
}
