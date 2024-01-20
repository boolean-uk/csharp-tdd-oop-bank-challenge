using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private List<Transaction> _transactions = new List<Transaction>();

        
        public string ID { get { return _ID; } }
        public AccountType Type { get { return _type; } }

        public List<Transaction> transactions { get { return _transactions; } }

        public Account(AccountType type)
        {
            _ID = Guid.NewGuid().ToString();
            _type = type;
        }

        public static Account createAccount(AccountType type)
        {
            switch (type)
            {
                case AccountType.GENERAL:
                    return new GeneralAccount(type);
                case AccountType.SAVINGS:
                    return new SavingsAccount(type);
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
            float currentBalance = getBalance();

            Transaction transaction = new Transaction(date, amount, type, currentBalance);


            if (transaction.TransactionType == TransactionType.WITHDRAW & currentBalance - transaction.Amount < 0)
            {
                Console.WriteLine("WITHDRAW DENIED!");
                return false;

            }

            _transactions.Add(transaction);
            return true;

        }

        public void ListBankStatement()
        {
            Console.WriteLine("    date    || credit  || debit  || balance");

            foreach (Transaction t in _transactions.OrderByDescending(x => x.DateTime))
            {
                if (t.TransactionType is TransactionType.DEPOSIT)
                {
                    Console.WriteLine($" {DateOnly.FromDateTime(t.DateTime)} || {t.Amount:0.00} ||        || {t.Balance + t.Amount:0.00}");
                }
                else
                {
                    Console.WriteLine($" {DateOnly.FromDateTime(t.DateTime.Date)} ||         || {t.Amount:0.00} || {t.Balance - t.Amount:0.00}");
                }
            }

        }

    }
}
