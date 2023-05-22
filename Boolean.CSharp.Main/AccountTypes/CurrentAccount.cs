using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : IAccount
    {
        public AccountType AccountType { get; set; }
        public BankBranchType BranchType { get; set; }
        public List<Transaction> Transactions { get; set; }

        public CurrentAccount(AccountType AccountType, BankBranchType BranchType, List<Transaction> Transactions)
        {
            this.AccountType = AccountType;
            this.BranchType = BranchType;
            this.Transactions = Transactions;
        }
    }
}