using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Class;
using Boolean.CSharp.Main.Enums;
using Transaction = Boolean.CSharp.Main.Class.Transaction;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Account
    {
        private Role _owner;
        private List<Transaction> _transactions;

        public Account(Role owner)
        {
            _owner = owner;
            _transactions = new List<Transaction>();
        }

        public void Withdraw(decimal amount) 
        {
            Transaction transaction = new Transaction(amount, TransactionType.Withdrawal);
            _transactions.Add(transaction);
        }

        public void Deposit(decimal amount)
        {
            Transaction transaction = new Transaction(amount, TransactionType.Deposit);
            _transactions.Add(transaction);
        }

        public decimal CalculateBalance()
        {
            decimal balance = 0;
            _transactions.Sort((x, y) => x.TransactionDate.CompareTo(y.TransactionDate));
            foreach (Transaction transaction in _transactions)
            {
                balance = transaction.Type == TransactionType.Deposit ? balance + transaction.Balance : balance - transaction.Balance;
            }
            return balance;
        }
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public Branch Branch { get; set; }
        public List<Transaction> Transactions { get => _transactions; set => _transactions = value; }
    }
}
