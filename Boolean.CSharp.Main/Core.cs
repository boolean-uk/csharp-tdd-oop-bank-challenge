using Newtonsoft.Json;
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
            Transaction tempT = new Transaction(amount, transactionType.withdraw, time, _balance);
            Transaction.Add(tempT);
            return tempT;
        }
        public Transaction deposit(float amount)
        {
            _balance += amount;
            DateTime time = DateTime.Now;
            Transaction tempT = new Transaction(amount, transactionType.deposit, time, _balance);
            Transaction.Add(tempT);
            return tempT;
        }
        public void printStatement()
        {
            Console.WriteLine("       date          || credit   ||   debit   ||  balance  ");
            foreach(Transaction t in transaction)
            {
                //string expectedJson = JsonConvert.SerializeObject(t);
                Console.WriteLine($"{t.Time}  ||  {t.Amount}     ||  {t.Type}  ||  {t.NewTotal}  ");
            }
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
        private float _newTotal;
        private transactionType _transactionType;
        private DateTime _time;
        public float Amount { get { return _amount; } }
        public float NewTotal { get { return _newTotal; } }
        public transactionType Type { get { return _transactionType; } }
        public DateTime Time { get { return _time; } }
        public Transaction(float amount, transactionType type, DateTime timeStamp, float newtotal)
        {
            _amount = amount;
            _transactionType = type;
            _time = timeStamp;
            _newTotal = newtotal;
        }
    }/*
    public class BankStatement
    {
        private List<Transaction> _transactions;
        public BankStatement()
        {

        }
        public void printStatement()
        {

        }
    }*/
}
