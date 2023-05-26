using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public class Transaction
    {
        public DateTime DateTime { get; set; }
        public decimal amount { get; set; }
        public decimal newBalance { get; set; }
        public TransactionType transactionType { get; set; }
    }
}
