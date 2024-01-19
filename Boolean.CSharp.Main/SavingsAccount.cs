using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Boolean.CSharp.Main
{
    public class SavingsAccount : IAccount
    {
        string _ID;
        List<Transaction> _transactions = new List<Transaction>();

        public SavingsAccount()
        {
            _ID = Guid.NewGuid().ToString();    
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

            foreach(Transaction t in _transactions)
            {
                if (t.TransactionType is TransactionType.DEPOSIT)
                {
                    Console.WriteLine($" {t.DateTime} ||         || {t.Amount} || {t.Balance + t.Amount} ");
                }
                else
                {
                    Console.WriteLine($" {t.DateTime} || {t.Amount}  ||        || {t.Balance - t.Amount} ");
                }
            }
        }

    }
}
