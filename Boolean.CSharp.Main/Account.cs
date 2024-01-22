﻿using System.Text;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        private string _name;
        private decimal _balance;
        private List<Transaction> _transactions;

        public string Name {  get { return _name; } }
        public decimal Balance { get { return _balance; } }
        public List<Transaction> Transactions { get { return _transactions; } }

        public Account(string name)
        {
            _name = name;
            _balance = 0;
            _transactions = new();
        }

        public decimal GetBalance()
        {
            throw new NotImplementedException();
        }

        public string Deposit(decimal amount)
        {
            _transactions.Add(new(TransactionType.Debit, amount, _balance));
            _balance += amount;
            return $"{amount} deposited to {_name}, new balance is {_balance}";
        }

        public string Withdraw(decimal amount)
        {
            Transaction withdrawal = new(TransactionType.Credit, amount, _balance);
            if (withdrawal.NewValue < 0) 
            {
                return $"Cannot withdraw from {_name}, balance is less than withdrawal amount";
            }
            _transactions.Add(withdrawal);
            _balance -= amount;
            return $"{amount} withdrawn from {_name}, new balance is {_balance}";
        }

        public string GenerateStatement()
        {
            StringBuilder sb = new();
            sb.AppendFormat("|{0,-10}| {1,-7}| {2,-7}| {3,-7}|\n", "date", "credit", "debit", "balance");
            foreach(Transaction transaction in _transactions)
            {
                if (transaction.Type == TransactionType.Credit)
                {
                    sb.AppendFormat("|{0,-10}| {1,-7}| {2,-7}| {3,-7}|\n", transaction.Date.ToString("dd/MM/yyyy"), transaction.Amount, 0, transaction.NewValue);
                }
                else
                {
                    sb.AppendFormat("|{0,-10}| {1,-7}| {2,-7}| {3,-7}|\n", transaction.Date.ToString("dd/MM/yyyy"), 0, transaction.Amount, transaction.NewValue);
                }
            }

            return sb.ToString();
        }
    }
}
