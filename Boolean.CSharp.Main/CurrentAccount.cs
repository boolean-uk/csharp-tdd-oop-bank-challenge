using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : IAccount
    {
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }

        public CurrentAccount(decimal balance, int AccountNumber)
        {
            this.Balance = balance;
            this.AccountNumber = AccountNumber;
        }
        public decimal Deposit(decimal amount)
        {
            if (amount < 0)
            {
                amount = 0;
            }
            this.Balance += amount;
            return this.Balance;
        }

        public decimal Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
