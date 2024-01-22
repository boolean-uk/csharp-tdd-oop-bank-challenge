using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;


namespace Boolean.CSharp.Main
{
    public enum AccountType
    {
        current,
        savings
    }
    public class Customer
    {
        private List<Account> accounts = new List<Account>();
        public List<Account> Accounts { get { return accounts; } }
        public Account createAccount(int accountNr, AccountType type)
        {
            if(type == AccountType.current)
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
        private List<Transaction> transactions = new List<Transaction>();
        public List<Transaction> Transactions { get { return transactions; } }
        public int AccountNumber { get { return _accountNr; } }
        public float Balance { get { return _balance; } }
        public Account(int accountNr)
        {
            _accountNr = accountNr;
        }
        public Transaction withdraw(float amount)
        {
            if(Balance-amount >= 0)
            {
                if(amount > 0)
                {
                    _balance -= amount;
                    DateTime time = DateTime.Now;
                    Transaction tempT = new Transaction(amount, TransactionType.withdraw, time.ToString("D"), _balance);
                    Transactions.Add(tempT);
                    return tempT;
                }
                else
                {
                    throw new WithdrawException("Withdrawl amount must be a positive floating point number!");
                }
            }
            else
            {
                throw new WithdrawException("You cannot withdraw more money than you have!");
            }
        }
        public Transaction deposit(float amount)
        {
            if(amount > 0)
            {
                _balance += amount;
                DateTime time = DateTime.Now;
                Transaction tempT = new Transaction(amount, TransactionType.deposit, time.ToString("D"), _balance);
                Transactions.Add(tempT);
                return tempT;
            }
            else
            {
                throw new DepositException("Deposit amount must be a positive floating point number!");
            }
        }
        public List<string> printStatement()
        {
            Console.WriteLine("       date              || credit   ||   debit   ||  balance  ");
            List<string> statements = new List<string>();
            foreach(Transaction t in transactions)
            {
                statements.Add($"{t.Time}  ||  {t.Amount}     ||  {t.Type}  ||  {t.NewTotalBalance}  ");
            }
            foreach(var t in statements)
            {
                Console.WriteLine(t);
            }
            return statements;
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
    public enum TransactionType
    {
        deposit,
        withdraw
    }
    public class Transaction
    {
        private float _amount;
        private float _newTotalBalance;
        private TransactionType _transactionType;
        private string _time;
        public float Amount { get { return _amount; } }
        public float NewTotalBalance { get { return _newTotalBalance; } }
        public TransactionType Type { get { return _transactionType; } }
        public string Time { get { return _time; } }
        public Transaction(float amount, TransactionType type, string timeStamp, float newtotalBalance)
        {
            _amount = amount;
            _transactionType = type;
            _time = timeStamp;
            _newTotalBalance = newtotalBalance;
        }
    }
    public class WithdrawException : Exception
    {
        public WithdrawException(string message) : base(message)
        {

        }
    }
    public class DepositException : Exception
    {
        public DepositException(string message) : base(message)
        {

        }
    }
}