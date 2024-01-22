using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            if (this.sortCode != sortCode)
                return false;

            if (amount < 0)
                return false;

            if (date == "")
                return false;

            transactions.Add(new Transaction(date, amount, 0.0f));
            Console.WriteLine("Deposited $" + amount + " on date " + date);
            return true;
        }

        public bool WithdrawFunds(string sortCode, float amount, string date, bool managerApprove = false)
        {
            if (this.sortCode != sortCode)
                return false;

            if (GetTotalBalance() < amount && !managerApprove)
                return false;

            if (date == "")
                return false;

            transactions.Add(new Transaction(date, 0.0f, amount));
            Console.WriteLine("Withdrew $" + amount + " on date " + date);
            return true;
        }

        public string GetTransactions(string sortCode)
        {
            if (this.sortCode != sortCode)
                return "";

            string message = "Date\t|| Credit || Debit || Balance\n";
            float balance = 0.0f;

            for (int i = 0; i < transactions.Count(); i++)
            {
                if (i > 0)
                    message += "\n";
                balance += transactions[i].GetBalance();
                message += transactions[i].date + " || " + transactions[i].credit + " || " + transactions[i].debit + " || " + balance;
            }

            return message;
        }

        public float GetTotalBalance()
        {
            float totalBalance = 0.0f;

            for (int i = 0; i < transactions.Count(); i++)
            {
                totalBalance += transactions[i].GetBalance();
            }

            return totalBalance;
        }
    }
}