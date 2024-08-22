using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        public AccountType Type { get; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }

        
    }
}
