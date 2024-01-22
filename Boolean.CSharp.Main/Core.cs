using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;


namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private string _branch;

        public Bank(string branch)
        {
            _branch = branch;
        }
        public void approveOverdraft(float overdraft)
        {

        }
    }
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
        private float _overdraft = 0;
        private List<Transaction> transactions = new List<Transaction>();
        public List<Transaction> Transactions { get { return transactions; } }
        public int AccountNumber { get { return _accountNr; } }
        public float Overdraft { get { return _overdraft; }}
        public Account(int accountNr)
        {
            _accountNr = accountNr;
        }
        public float getTotal()
        {
            float total = 0;
            foreach(Transaction transaction in transactions)
            {
                if(transaction.Type == TransactionType.deposit)
                {
                    total += transaction.Amount;
                }
                else if(transaction.Type == TransactionType.withdraw)
                {
                    total -= transaction.Amount;
                }
            }
            return total;
        }
        public Transaction withdraw(float amount)
        {
            if (amount > 0)
            {
                if(amount <= getTotal())
                {
                    DateTime time = DateTime.Now;
                    Transaction tempT = new Transaction(amount, TransactionType.withdraw, time.ToString("D"));
                    Transactions.Add(tempT);
                    return tempT;
                }
                else
                {
                    throw new WithdrawException("You cannot withdraw more money than you have!");
                }
            }
            else
            {
                throw new WithdrawException("Withdrawl amount must be a positive floating point number!");
            }
        }
        public Transaction deposit(float amount)
        {
            if(amount > 0)
            {
                DateTime time = DateTime.Now;
                Transaction tempT = new Transaction(amount, TransactionType.deposit, time.ToString("D"));
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
                statements.Add($"{t.Time}  ||  {t.Amount}     ||  {t.Type}  ||  !!!!!!!TOTAL!!!!!!  ");
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
        private TransactionType _transactionType;
        private string _time;
        public float Amount { get { return _amount; } }
        public TransactionType Type { get { return _transactionType; } }
        public string Time { get { return _time; } }
        public Transaction(float amount, TransactionType type, string timeStamp)
        {
            _amount = amount;
            _transactionType = type;
            _time = timeStamp;
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