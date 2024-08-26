using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingAccount : IAccount
    {
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }

        public SavingAccount(decimal balance, int accountNumber)
        {
            this.Balance = balance;
            this.AccountNumber = accountNumber;
        }

        public decimal Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public decimal Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
