using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{

    public enum AccountType {
        CURRENT = 1,
        SAVINGS = 2,
    }
    public abstract class Account : IAccount
    {
        public string AccountName { get; private set;}

        public decimal Balance { get; private set;}

        private List<Transactions> _transactions = new List<Transactions>();

        public Account(string accountname, decimal balance) {
            
            if (!string.IsNullOrEmpty(accountname)) {
                AccountName = accountname;
            } else {
                throw new Exception("You can not have an empty account name");
            }

            if (balance >= 0) {
                Balance = balance;
            } else {
                throw new Exception($"{balance} is not a valid starting balence, the balance must be 0 or greater");
            }
        }

        public void Deposit(decimal amount) {
            if (amount > 0) {
                Balance += amount;
                AddTransaction(amount, TransactionType.DEPOSIT);
            } else {
                throw new InvalidOperationException($"{amount} is not a Deposit amount our bank accepts, the deposit amount needs to be greater than 0");
            }
            
            
        }

        public void Withdraw(decimal amount) {
            if (Balance >= amount && amount > 0) {
                Balance -= amount;
                AddTransaction(amount, TransactionType.WITHDRAW);
            } else {
                throw new InvalidOperationException($"This account have insufficient funds to make the transation on {amount} since the balance is {Balance}");
            }
            
            
        }

        public string GenerateStatement() {
            string statement = $"statement from {AccountName}";
            if (_transactions.Count <= 0) {
                return $"\nNo transaction history for account: {AccountName}";
            }
            statement += "\nDate    ||    Withdraw    ||    Deposit   || Balance";
            foreach (Transactions transation in _transactions) {
                string date = transation.DateOfTransaction;
                string withdraw = transation.Type == TransactionType.WITHDRAW ? transation.Amount.ToString("F2") : "0,00";
                string deposit = transation.Type == TransactionType.DEPOSIT ? transation.Amount.ToString("F2") : "0,00";
                statement += $"\n{date}    ||   {withdraw}    ||    {deposit}     ||    {transation.Balance}";

            }

            return statement;
            
        }

        private void AddTransaction(decimal amount, TransactionType type) {
            var transation = new Transactions(amount, type, Balance, this);
            _transactions.Add(transation);
        }

        public int GetTransactionListCount() {
            return _transactions.Count;
        }

        public abstract AccountType GetAccountType();

      
    }
}