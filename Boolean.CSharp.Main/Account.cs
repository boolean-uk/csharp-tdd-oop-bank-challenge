using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{

    public enum AccountType {
        CURRENT = 1,
        SAVINGS = 2,
    }
    public abstract class Account : IAccount
    {
        public string? AccountName { get; private set;}

        public decimal? Balance { get; private set;}

        List<Transactions> _transactions = new List<Transactions>();

        public Account(string accountname, decimal balance) {
            AccountName = accountname;
            Balance = balance;
        }

        public void Deposit(decimal amount) {

            throw new NotImplementedException();
        }

        public void Withdraw(decimal amount) {

            throw new NotImplementedException();
        }

        public string GenerateStatement() {

            throw new NotImplementedException();
        }

        private void AddTransaction(decimal amount, TransactionType type) {

        }

        public abstract AccountType GetAccountType();

      
    }
}