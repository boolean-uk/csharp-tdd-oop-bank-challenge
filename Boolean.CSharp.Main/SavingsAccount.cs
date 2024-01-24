using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : IAccount
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public Account Type { get; set; }
        public Branch Branch { get; set; }
        public Overdraft Overdraft { get; set; }

        public void createSavingsAccount(int accountId, decimal balance, string AccountType, string branch, string overdraft)
        {
            this.AccountId = accountId;
            this.Balance = balance;
            this.Type = Account.Current;
            this.Branch = default;
            this.Overdraft = default;
        }
    }
}

