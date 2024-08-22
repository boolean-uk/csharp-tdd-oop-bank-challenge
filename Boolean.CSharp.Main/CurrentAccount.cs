using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : IAccount
    {
        public AccountType Type { get; } = AccountType.Current;
        public decimal Balance { get; set; } = 0m;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
  
    }
}
