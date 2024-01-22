using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models.Accounts
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Branch AssociatedBranch { get; set; }
        public string PhoneNumber { get; set; }

        public Account(Branch branch, string phoneNumber)
        {
            AccountNumber = AccountNumberGenerator.GetID();
            Transactions = new List<Transaction>();
            AssociatedBranch = branch;
            PhoneNumber = phoneNumber;
        }

        public double Balance
        {
            get { return Transactions.Sum(t => t.Type == TransactionType.Credit ? t.Amount : -t.Amount); }
        }

        public virtual void Deposit(double amount)
        {
            Transaction transaction = new Transaction(amount, TransactionType.Credit);
            Transactions.Add(transaction);
        }

        public virtual void Withdraw(double amount)
        {
            Transaction latestTransaction = Transactions.OrderBy(t => t.Date).FirstOrDefault();

            if (latestTransaction != null)
                throw new InvalidOperationException();

            if (amount > GetBalanceAfterTransaction(latestTransaction))
                throw new InvalidOperationException("Insufficient funds for withdrawal.");

            Transaction transaction = new Transaction(amount, TransactionType.Debit);
            Transactions.Add(transaction);
        }

        public double GetBalanceAfterTransaction(Transaction transaction)
        {
            return Transactions.Where(t => t.Date >= transaction.Date).Sum(t => t.Type == TransactionType.Credit ? t.Amount : -t.Amount);
        }

        private string GenereateStatment()
        {
            throw new NotImplementedException();
        }

        public void sendStatmentMessage(string statment)
        {
            throw new NotImplementedException();
        }
    }

    public class AccountNumberGenerator
    {
        private static int currentID = 0;

        public static int GetID()
        {
            return ++currentID;
        }
    }
}
