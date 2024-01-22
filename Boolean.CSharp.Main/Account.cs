using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private string _accountName;
        private decimal _balance;
        private List<Tuple<BankTransaction, decimal>> _transactions = [];


        public void Deposit(BankTransaction transaction)
        {
            if (transaction.Type == "Credit")
            {
                Balance += transaction.Amount;
                Transactions.Add(Tuple.Create(transaction, Balance));

            }
        }

        public void Withdraw(BankTransaction transaction)
        {
            if (transaction.Type == "Debit")
            {
                
                if (Balance >= transaction.Amount)
                {
                    Balance -= transaction.Amount;
                    Transactions.Add(Tuple.Create(transaction, Balance));
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
        public List<Tuple<BankTransaction, decimal>> Transactions { get { return _transactions; } set { _transactions = value; } }
    }
}
