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
        public int AccountNr { get { return _accountNr; } }
        public float Balance { get { return _balance; } }
        public Account(int accountNr)
        {
            _accountNr = accountNr;
        }
        public void withdraw(float amount)
        {
            _balance -= amount;
        }
        public void deposit(float amount)
        {
            _balance += amount;
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
    public class Transaction
    {
        private float _amount;
        private string _type;
        private DateTime _timeStamp;
        public Transaction()
        {

        }
        public Transaction createTransaction()
        {
            return this;
        }
    }
    public class BankStatement
    {
        private List<Transaction> transaction;
        public BankStatement()
        {

        }
        public void printStatement()
        {

        }
    }
}
