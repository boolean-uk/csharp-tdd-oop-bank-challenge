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
        protected int _overdraft;

        protected Account(User owner, Branch branch)
        {
            _owner = owner;
            _branch = branch;
            _overdraft = 0;
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
                else if (t.TransactionAction == TransactionAction.Debit)
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
            if (amount > GetBalance() + _overdraft)
            {
                return false;
            }
            Transaction newTransaction = new Transaction(amount, GetBalance(), TransactionAction.Debit);
            _transactions.Add(newTransaction);
            return true;
        }

        public string GetBankStatement()
        {
            StringBuilder bankStatement = new StringBuilder(string.Empty);
            if (_transactions.Count <= 0)
            {
                return string.Empty;
            }

            bankStatement.AppendLine("date       || credit  || debit  || balance");
            foreach (Transaction t in _transactions)
            {
                bankStatement.Append($"{t.DateCreated} || ");
                if (t.TransactionAction == TransactionAction.Credit)
                {
                    bankStatement.Append($"{t.Amount}.00 ||        || ");
                }
                else if(t.TransactionAction == TransactionAction.Debit)
                {
                    bankStatement.Append($"        || {t.Amount}.00 || ");
                }
                bankStatement.AppendLine($"{t.Balance}.00");
            }
            return bankStatement.ToString();
        }

        public bool SetOverdraft(int amount, User userAttemptingAction)
        {
            if (userAttemptingAction.Role != Role.Manager)
            {
                return false;
            }
            _overdraft = amount;
            return true;
        }

        public Branch Branch { get { return _branch; } }
    }
}