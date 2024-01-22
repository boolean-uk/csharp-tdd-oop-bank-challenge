using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;


namespace Boolean.CSharp.Main
{
    public enum accountType
    {
        current,
        savings
    }
    public class Customer
    {
        private List<Account> accounts = new List<Account>();
        public List<Account> Accounts { get { return accounts; } }
        public Account createAccount(int accountNr, accountType type)
        {
            if(type == accountType.current)
            {
                CurrentAccount account = new CurrentAccount(accountNr);
                accounts.Add(account);
                return account;
            }
            else
            {
                SavingsAccount account = new SavingsAccount(accountNr);
                accounts.Add(account);
                return account;
            }
        }
    }
    public abstract class Account
    {
        private int _accountNr;
        private float _balance = 0;
        private List<Transaction> transaction = new List<Transaction>();
        public List<Transaction> Transaction { get { return transaction; } }
        public int AccountNr { get { return _accountNr; } }
        public float Balance { get { return _balance; } }
        public Account(int accountNr)
        {
            _accountNr = accountNr;
        }
        public Transaction withdraw(float amount)
        {
            _balance -= amount;
            DateTime time = DateTime.Now;
            Transaction tempT = new Transaction(amount, transactionType.withdraw, time);
            Transaction.Add(tempT);
            return tempT;
        }
        public Transaction deposit(float amount)
        {
            _balance += amount;
            DateTime time = DateTime.Now;
            Transaction tempT = new Transaction(amount, transactionType.deposit, time);
            transaction.Add(tempT);
            return tempT;
        }
    }
    public class CurrentAccount : Account
    {
        public CurrentAccount(int accountNr) : base(accountNr)
        {

        }
    }
    public class SavingsAccount : Account
    {
        public SavingsAccount(int accountNr) : base(accountNr)
        {

        }
    }
    public enum transactionType
    {
        deposit,
        withdraw
    }
    public class Transaction
    {
        
        private float _amount;
        private transactionType _transactionType;
        private DateTime _time;
        public Transaction(float amount, transactionType type, DateTime timeStamp)
        {
            _amount = amount;
            _transactionType = type;
            _time = timeStamp;
        }
        public Transaction createTransaction()
        {
            return this;
        }
    }
    public class BankStatement
    {
        public BankStatement()
        {

        }
        public void printStatement()
        {

        }
    }
}
