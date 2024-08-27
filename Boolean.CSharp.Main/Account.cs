using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        private decimal _balance = 0;


        public Account(decimal number)
        {
            this._balance = number;
        }

        public decimal GetBalance()
        {
            decimal temp = _balance;
            return temp;
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            _balance -= amount;
        }
    }
}
