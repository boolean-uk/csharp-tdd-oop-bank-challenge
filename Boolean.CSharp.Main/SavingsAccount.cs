using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

        public bool MakeTransaction(Transaction transaction)
        {
            float currentBalance = getBalance();

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

        }

    }
}
