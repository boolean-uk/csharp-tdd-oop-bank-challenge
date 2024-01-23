using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main
{
    public class CurrentAcc : IAccount
    {
        public AccountType accountType { get; set; }
        public List<Transaction> Transactions { get; set; }

       

        public CurrentAcc(AccountType accountType, List<Transaction> transactions)
        {
            this.accountType = accountType;
            this.Transactions = transactions; 

        }
    }
}
