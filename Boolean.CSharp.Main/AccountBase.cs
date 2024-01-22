using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.Utilities;


namespace Boolean.CSharp.Main
{
    public abstract class AccountBase : IAccount
    {
        private float _balance;
        private List<Transaction> _transactions;
        private string _accountName;
        private BankStatementBuilder _bankStatementBuilder;
        public float Balance => _balance;
        public List<Transaction> Transactions => _transactions;
        public string AccountName => _accountName;

        public AccountBase(string accountname, BankStatementBuilder bankStatementBuilder){
            _accountName = accountname;
            _bankStatementBuilder = bankStatementBuilder;
            _transactions = new List<Transaction>();
        }
        public bool Deposit(float amount)
        {
            if (amount <= 0)
            {
                return false;
            }
            _balance += amount;
            _transactions.Add(new Transaction(DateTime.Now, Transaction.TransactionType.Credit, amount, this._balance));
            return true;
        }

        public bool Withdraw(float amount)
        {
            if (amount <= 0)
            {
                return false;
            }
            if (_balance >= amount)
            {
                _balance -= amount;
                _transactions.Add(new Transaction(DateTime.Now, Transaction.TransactionType.Debit, amount, this._balance));
                return true;
            }
            return false;
        }

        public string GetBankStatement()
        {
            string output = _bankStatementBuilder.BuildStatement(_transactions);
            return output;
        }
    }
}