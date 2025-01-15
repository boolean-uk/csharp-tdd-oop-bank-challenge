using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Class;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interface;
using Transaction = Boolean.CSharp.Main.Class.Transaction;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Account
    {
        private Role _owner;
        private List<Transaction> _transactions;
        private Branch _branch;

        public Account(Role owner)
        {
            _owner = owner;
            _transactions = new List<Transaction>();
        }

        public void Withdraw(decimal amount, DateTime? customDate = null) 
        {
            if (this is IOverdraftable overdraftable && CalculateBalance() - amount > -overdraftable.OverdraftLimit)
            {
                Transaction transaction = new Transaction(amount, TransactionType.Withdrawal, customDate);
                _transactions.Add(transaction);
            }
            else if (CalculateBalance() - amount < 0)
            {
                Console.WriteLine("You cannot withdraw more funds");
            }
            else
            {
                Transaction transaction = new Transaction(amount, TransactionType.Withdrawal, customDate);
                _transactions.Add(transaction);
            }
           
        }

        public void Deposit(decimal amount, DateTime? customDate = null)
        {
            Transaction transaction = new Transaction(amount, TransactionType.Deposit, customDate);
            _transactions.Add(transaction);
        }

        public decimal CalculateBalance()
        {
            decimal balance = 0;
            _transactions.Sort((x, y) => y.TransactionDate.CompareTo(x.TransactionDate)); // Descending order
            foreach (Transaction transaction in _transactions)
            {
                balance = transaction.Type == TransactionType.Deposit ? balance + transaction.Balance : balance - transaction.Balance;
            }
            return balance;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("date       || credit  || debit  || balance");

            decimal runningBalance = 0;
            _transactions.Sort((x, y) => x.TransactionDate.CompareTo(y.TransactionDate)); // Ascending order

            // Store the transactions in a list so we can reverse it before printing the statement
            List<string> transactions = new List<string>();
            foreach (var transaction in _transactions)
            {
                decimal credit = transaction.Type == TransactionType.Deposit ? transaction.Balance : 0;
                decimal debit = transaction.Type == TransactionType.Withdrawal ? transaction.Balance : 0;
                runningBalance += credit - debit;

                transactions.Add($"{transaction.TransactionDate:dd/MM/yyyy} || {credit,7} || {debit,6} || {runningBalance,7}");
            }

            transactions.Reverse();
            transactions.ForEach(x =>
            {
                builder.AppendLine(x);
            });
            
            return builder.ToString();
        }
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public Branch Branch { get => _branch; set => _branch = value; }
        public List<Transaction> Transactions { get => _transactions; set => _transactions = value; }
    }
}
