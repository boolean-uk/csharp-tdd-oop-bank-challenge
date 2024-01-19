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
        public Customer()
        {

        }
        public Account createAccount(int accountNr, accountType type)
        {
            return null;
        }
    }
    public abstract class Account
    {
        private string _type;
        private int _accountNr;
        private float _balance;
        public string Type { get { return _type; } }
        public int AccountNr { get { return _accountNr; } }
        public float Balance { get { return _balance; } }
        public Account(string type, int accountNr, float balance)
        {
            _type = type;
            _accountNr = accountNr;
            _balance = balance;
        }
        public void withdraw(int accountNr, float amount)
        {

        }
        public void deposit(int accountNr, float amount)
        {

        }
    }
    public class CurrentAccount : Account
    {
        public CurrentAccount(string type, int accountNr, float balance) : base(type, accountNr, balance)
        {

        }
    }
    public class SavingsAccount : Account
    {
        public SavingsAccount(string type, int accountNr, float balance) : base(type, accountNr, balance)
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
