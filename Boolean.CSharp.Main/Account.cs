using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        public string accountNumber;
        public string customerName;
        public float startBalance;
        public string accountType;
        public float allowOverdraft = 0;
        public List<Transaction> transactions = new List<Transaction>();

        public Account(string accountNumber, string customerName, float startBalance, string accountType)
        {
            this.accountNumber = accountNumber;
            this.customerName = customerName;
            this.startBalance = startBalance;
            this.accountType = accountType;
            this.transactions = new List<Transaction>();
        }

        public float GetBalance()
        {
            float transactionTotal = 0;
            foreach (Transaction t in transactions)
            {
                transactionTotal += t.transactionAmount;
            }
            return startBalance + transactionTotal;
        }

    }
}
