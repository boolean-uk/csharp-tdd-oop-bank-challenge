using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Account
    {
        protected float balance;
        List<Transaction> transactions;

        public Account()
        {
            balance = 0.0f;
            transactions = new List<Transaction>();
        }

        public bool DepositFunds(float amount, string date)
        {
            if (amount < 0)
                return false;

            if (date == "")
                return false;

            balance += amount;
            transactions.Add(new Transaction(date, amount, 0.0f, balance));
            return true;
        }

        public bool WithdrawFunds(float amount, string date)
        {
            if (balance < amount)
                return false;

            if (date == "")
                return false;

            balance -= amount;
            transactions.Add(new Transaction(date, 0.0f, amount, balance));
            return true;
        }

        public string GetTransactions()
        {
            string message = "Date\t|| Credit || Debit || Balance\n";

            for (int i = 0; i < transactions.Count(); i++)
            {
                if (i > 0)
                    message += "\n";
                message += transactions[i].date + " || " + transactions[i].credit + " || " + transactions[i].debit + " || " + transactions[i].balance;
            }

            return message;
        }
    }
}