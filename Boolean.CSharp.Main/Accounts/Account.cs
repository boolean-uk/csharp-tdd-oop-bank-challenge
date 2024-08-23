using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        protected User _owner;
        protected List<Transaction> _transactions = new List<Transaction>();
        protected Branch _branch;

        protected Account(User owner, Branch branch)
        {
            _owner = owner;
            _branch = branch;
        }

        public int GetBalance()
        {
            int balance = 0;
            foreach (Transaction t in _transactions)
            {
                if (t.TransactionAction == TransactionAction.Credit)
                {
                    balance += t.Amount;
                }
                else if (t.TransactionAction != TransactionAction.Debit)
                {
                    balance -= t.Amount;
                }
            }
            return balance;
        }

        public bool Deposit(int amount)
        {
            Transaction newTransaction = new Transaction(amount, GetBalance(), TransactionAction.Credit);
            _transactions.Add(newTransaction);
            return true;
        }

        public bool Withdraw(int amount)
        {
            return false;
        }

        public string GetBankStatement()
        {
            return string.Empty;
        }

        public bool SetOverdraft(int amount, User userAttemptingAction)
        {
            return false;
        }

        public Branch Branch { get { return _branch; } }
    }
}