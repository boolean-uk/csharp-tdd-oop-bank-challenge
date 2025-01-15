using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private string _accountName;
        private Branch _branch;
        private List<Transaction> _transactions;

        public string AccountName { get { return _accountName; } }
        public Branch Branch { get { return _branch; } }
        public List<Transaction> TransactionHistory { get { return _transactions; } }

        public Account(string accountName, Branch branch) 
        { 
            _accountName = accountName;
            _branch = branch;
            _transactions = new List<Transaction>();
        }

        public void Deposit(decimal amount)
        {
            Transaction credit = new Transaction(amount, TransactionType.Credit);
            TransactionHistory.Add(credit);
        }

        public virtual void Withdraw(decimal amount)
        {
            var balance = CalculateBalance();
            if (balance >= amount)
            {
                Transaction debit = new Transaction(amount, TransactionType.Debit);
                TransactionHistory.Add(debit);
            }
            else
            {
                Console.WriteLine("Withdrawal failed");
            }
        }

        public void AddTransaction(Transaction transaction)
        { 
            _transactions.Add(transaction); 
        }

        public decimal CalculateBalance()
        {
            var balance = _transactions.Sum(t => t.GetAmount());
            return balance;
        }

        public string GenerateBankStatement()
        {
            var statement = new StringBuilder();

            var balance = CalculateBalance();
            statement.AppendLine($"date{" ",6} || credit{" ",4} || debit {" ",4} || balance {" ",5}");
            foreach (var transaction in _transactions.AsEnumerable().Reverse())
            {
                statement.AppendLine(transaction.ToString(balance));
                balance -= transaction.GetAmount();
            }

            return statement.ToString();

        }
    }
}