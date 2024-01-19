using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Account
    {
        private List<Transaction> transactions;
        protected string sortCode;

        public Account(string sortCode)
        {
            transactions = new List<Transaction>();
            this.sortCode = sortCode;
        }

        public bool DepositFunds(string sortCode, float amount, string date)
        {
            if (amount < 0)
                return false;

            if (date == "")
                return false;

            transactions.Add(new Transaction(date, amount, 0.0f));
            return true;
        }

        public bool WithdrawFunds(string sortCode, float amount, string date)
        {
            if (date == "")
                return false;

            transactions.Add(new Transaction(date, 0.0f, amount));
            return true;
        }

        public string GetTransactions(string sortCode)
        {
            string message = "Date\t|| Credit || Debit || Balance\n";

            for (int i = 0; i < transactions.Count(); i++)
            {
                if (i > 0)
                    message += "\n";
                message += transactions[i].date + " || " + transactions[i].credit + " || " + transactions[i].debit;
            }

            return message;
        }

        public float GetBalance(string sortCode)
        {
            return 0.0f;
        }

        private void PrintStatements()
        {

        }
    }
}