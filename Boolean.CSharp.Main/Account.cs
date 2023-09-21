using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private string _number;
        private int _customerId;
        List<Transaction> _transactions = new List<Transaction>();

        public Account(int customerId)
        {
            _number = GenerateAccountNumber();
            _customerId = customerId;
        }

        private string GenerateAccountNumber()
        {
            /** NOTE:
             * generate an 7-digit random number as presented here:
             * https://stackoverflow.com/a/14734156
             * change string to an 8-digit format as presented here:
             * https://stackoverflow.com/a/44383892
            */
            Random rnd = new Random();
            int myRandomNo= rnd.Next(0, 9999999);
            return myRandomNo.ToString("00000000");
        }

        public decimal GetBalance()
        {
            if (_transactions.Count == 0)
                return 0.0m;
            
            // NOTE: keep _transactions list sorted (most frequent transaction first), so that the balance is always accessible by retrieving the NewBalance from the first element
            return _transactions[0].NewBalance;
        }

        public void Deposit(decimal amount)
        {
            _transactions.Insert(0, new Transaction(DateTime.Now, TransactionType.Credit, amount, GetBalance()));
        }

        public void Withdraw(decimal amount)
        {
            
        }

        public string Number { get => _number; }
    }
}
