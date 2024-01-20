using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Boolean.CSharp.Main
{
    public enum AccountType
    {
        GENERAL,
        SAVINGS
    }

    public abstract class Account : IAccount
    {
        private string _ID;
        private AccountType _type;
        private string _branch;
        private List<Transaction> _transactions = new List<Transaction>();

        
        public string ID { get { return _ID; } }
        public AccountType ACCTYPE { get { return _type; } }

        public string BRANCH { get { return _branch; } }
        public List<Transaction> transactions { get { return _transactions; } }

        public Account(AccountType type, string branch)
        {
            _ID = Guid.NewGuid().ToString();
            _type = type;
            _branch = branch;
        }

        public static Account createAccount(AccountType type, string branch)
        {
            List<string> _branches = new List<string> { "ITALY", "SPAIN", "FRANCE" };

            if (!_branches.Contains(branch))
            {
                throw new Exception("Branch does not exist!");
            }

            switch (type)
            {
                case AccountType.GENERAL:
                    return new GeneralAccount(type, branch);
                case AccountType.SAVINGS:
                    return new SavingsAccount(type, branch);
                default:
                    throw new Exception("account type does not exist!");
            }
        }

        public float getBalance()
        {
            float deposits = _transactions.Where(x => x.TransactionType == TransactionType.DEPOSIT).Select(x => x.Amount).ToList().Sum();
            float withdraws = _transactions.Where(x => x.TransactionType == TransactionType.WITHDRAW).Select(x => x.Amount).ToList().Sum();
            return deposits - withdraws;
        }

        public bool MakeTransaction(float amount, TransactionType type, string date)
        {
            float currentBalance = (type == TransactionType.DEPOSIT) ? getBalance() + amount : getBalance() - amount;

            Transaction transaction = new Transaction(date, amount, type, currentBalance);

            if (type == TransactionType.WITHDRAW & getBalance() - transaction.Amount < 0)
            {
                Console.WriteLine("WITHDRAW DENIED!");
                return false;

            }

            _transactions.Add(transaction);
            return true;

        }
        public bool MakeTransaction(float amount, TransactionType type)
        {
            
            float currentBalance = (type == TransactionType.DEPOSIT) ? getBalance() + amount : getBalance() - amount;

            Transaction transaction = new Transaction(amount, type, currentBalance);

            if (transaction.TransactionType == TransactionType.WITHDRAW & getBalance() - transaction.Amount < 0)
            {
                Console.WriteLine("WITHDRAW DENIED!");
                return false;

            }

            _transactions.Add(transaction);
            return true;

        }

        public void ListBankStatement()
        {
            Console.WriteLine("    date    ||  credit ||  debit  || balance");

            foreach (Transaction t in _transactions.OrderByDescending(x => x.DateTime))
            {
                if (t.TransactionType is TransactionType.DEPOSIT)
                {
                    Console.WriteLine("{0,12}||{1,9:0.00}||{2,9:0.00}||{3,9:0.00}", DateOnly.FromDateTime(t.DateTime), t.Amount, "", t.Balance);
                   
                }
                else
                {
                    Console.WriteLine("{0,12}||{1,9:0.00}||{2,9:0.00}||{3,9:0.00}", DateOnly.FromDateTime(t.DateTime), "", t.Amount, t.Balance);
                }
            }

        }

    }
}
