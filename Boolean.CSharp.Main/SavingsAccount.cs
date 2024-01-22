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
        private List<Tuple<Transaction, decimal>> _transactions = [];


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
                Transactions.Add(Tuple.Create(transaction, Balance));

            }
        }

        public void Withdraw(Transaction transaction)
        {
            if (transaction.Type == "Debit")
            {
                try
                {
                    if (Balance >= transaction.Amount)
                    {
                        Balance -= transaction.Amount;
                        Transactions.Add(Tuple.Create(transaction, Balance));

                    }
                }
                catch 
                {
                    throw new ArgumentException("You don't have the funds for this type of transaction");
                }


            }
        }
        public void PrintStatement()
        {
            Console.WriteLine($"Date    ||Credit    ||Debit     ||Balance");
            foreach (var item in Transactions)
            {
                if (item.Item1.Type == "Credit")
                {
                    Console.WriteLine($"{item.Item1.TransactionDate.Date.ToString("dd/MM/yy")}||{item.Item1.Amount}     ||          ||{item.Item2}");
                };
                if (item.Item1.Type == "Debit")
                {
                    Console.WriteLine($"{item.Item1.TransactionDate.Date.ToString("dd/MM/yy")}||          ||{item.Item1.Amount}     ||{item.Item2}");
                }
            }
        }



        public decimal Balance { get { return _balance; } set { _balance = value; } }
        public List<Tuple<Transaction, decimal>> Transactions { get { return _transactions; } set { _transactions = value; } }


    }
}
