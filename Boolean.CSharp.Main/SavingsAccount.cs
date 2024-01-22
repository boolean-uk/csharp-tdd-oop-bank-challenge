using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{

    public class SavingsAccount : IAccount
    {

        private string _accountName;
        private decimal _balance;
        private User _user;

        public SavingsAccount(string accountName, User user)
        {
            _accountName = accountName;
            _user = user;
        }

        public SavingsAccount(string accountName, User user, decimal balance)
        {
            _accountName = accountName;
            _user = user;
            _balance = balance;
        }
        public void Deposit(Transaction transaction)
        {
            if (transaction.Type == "Credit")
            {
                Balance += transaction.Amount;
            }
        }

        public void Withdraw(Transaction transaction)
        {
            if (transaction.Type == "Debit")
            {
                if (Balance >= transaction.Amount)
                {
                    Balance -= transaction.Amount;
                }
            }
        }
        public void PrintStatement()
        {
            throw new NotImplementedException();
        }



        public decimal Balance { get { return _balance; } set { _balance = value; } }

    }
}
