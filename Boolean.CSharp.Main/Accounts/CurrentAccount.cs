using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : IAccount
    {
        public AccountType Type { get; } = AccountType.Current;
        public decimal Balance { get; set; } = 0m;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
  
        public bool Deposit(decimal amount)
        {
            if (amount < 0) 
                return false; 

            Balance += amount;
            Transaction transaction = new Transaction(amount, Balance, TransactionType.Deposit);
            Transactions.Add(transaction);

            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if ((Balance - amount) < 0) //Not enough money in account
                return false;

            Balance -= amount;
            Transaction transaction = new Transaction(amount, Balance, TransactionType.Withdraw);
            Transactions.Add(transaction);

            return true;
        }
    }
}
