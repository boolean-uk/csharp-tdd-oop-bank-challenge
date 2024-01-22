using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class LogTransaction
    {
    //    private List<string> _logs = new List<string>();
        private List<Transaction> _transactions = new List<Transaction>();
        public Transaction AddLog(float change)
        {
            Transaction transaction = new Transaction();
            transaction.date = DateTime.Now;
            transaction.change = change;
            transaction.newBalance = CurrentBalance() + change;
            _transactions.Add(transaction);
            return transaction;
        }
        public void Print()
        {
            Console.WriteLine("Date       || Credit  || Debit   || Balance ");
            foreach (Transaction transaction in _transactions)
            {
                Console.WriteLine(transaction.ToString()) ;
            }
        }

        public float CurrentBalance()
        {
            float result = 0;
            foreach (Transaction transaction in _transactions)
            {
                result += transaction.change;
            }
            return result;
        }
    }

    public struct Transaction
    {
        public DateTime date;
        public float change;
        public float newBalance;
        public override string ToString()
        {
            string formattedString = Math.Abs(change).ToString("0.00");
            while (formattedString.Length < 7)
                formattedString = " " + formattedString;
            string formattedNewBalance = newBalance.ToString("0.00");
            while (formattedNewBalance.Length < 7)
                formattedNewBalance = " " + formattedNewBalance;
            string result;
            string dateString = date.ToString("d");
            if (change > 0)
            {
                result = $"{dateString} || {formattedString} ||         || {formattedNewBalance}";
            }
            else if (change < 0)
            {
                result = $"{dateString} ||         || {formattedString} || {formattedNewBalance}";

            }
            else result = $"{dateString} ||         ||         || {formattedNewBalance}";
            return result;
        }
    }
}
