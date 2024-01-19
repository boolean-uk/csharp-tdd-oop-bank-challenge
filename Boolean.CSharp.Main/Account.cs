using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Account
    {
        protected float balance;
        List<Transaction> transactions;

        public Account()
        {
            balance = 0.0f;
            transactions = new List<Transaction>();
        }

        public bool DepositFunds(float amount)
        {
            return false;
        }

        public bool WithdrawFunds(float amount)
        {
            return false;
        }

        public string GetTransactions()
        {
            return "";
        }
    }
}