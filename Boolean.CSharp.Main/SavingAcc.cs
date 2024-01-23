using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingAcc : IAccount
    {
        public AccountType accountType { get; set; }
        public List<Transaction> Transactions { get; set; }

       

        public SavingAcc(AccountType accountType, List<Transaction> transactions)
        {
            this.accountType = accountType;
            this.Transactions = transactions;
        }
    }
}
