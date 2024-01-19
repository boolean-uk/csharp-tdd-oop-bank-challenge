using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class GeneralAccount : IAccount
    {

        private string _ID;
        List<Transaction> _transactions = new List<Transaction>();

        public GeneralAccount()
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
