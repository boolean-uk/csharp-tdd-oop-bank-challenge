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

        public void MakeTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }
    }
}
