using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Boolean.CSharp.Main
{

    public interface Iaccount
    {
        public List<Transaction> GetTransactions();
        public bool AddTransaction(float f, DateTime? date );
        public float GetBalance();
        string GenerateTransationsHistory();
    }
    public class Account : Iaccount
    {
        private List<Transaction> transactions;

    
        public Account() {
            transactions = new List<Transaction>() ;
        }

        
        public bool AddTransaction(float transactionAmount, DateTime? date)
        {
            if (transactionAmount == 0f) { return false; }

            if (date != null)
                {
                transactions.Add(new Transaction(date.Value, transactionAmount)); return true;
                }

            transactions.Add(new Transaction(DateTime.Now, transactionAmount)); return true;
        }


        public float GetBalance()
        {
            float balance = 0;

            balance += transactions.Aggregate(0f, (tot, next) => tot + next.Amount);

            return balance;

        }
        

        public List<Transaction> GetTransactions() { return transactions; }


        public string GenerateTransationsHistory()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("date || credit || debit || balance\n");
            float total = GetBalance();
            string div = " || ";
            string floatFormatting = "{0:0.00}";

            foreach (Transaction t in transactions.OrderByDescending(t => t.CreationDate)) {
                sb.Append(t.CreationDate.Day + " / " + string.Format("{0:00}", t.CreationDate.Month) + " / " + t.CreationDate.Year);
                sb.Append(div);

                if (t.Amount >= 0) { sb.Append(string.Format(floatFormatting, t.Amount)); } else { sb.Append(""); };

                sb.Append(div);

                if (t.Amount <= 0) { sb.Append(string.Format(floatFormatting, Math.Abs(t.Amount))); } else { sb.Append(""); };

                sb.Append(div);
                
                sb.Append(string.Format(floatFormatting, total));
                total -= t.Amount;


            
            
                sb.Append('\n');
                }

            Console.WriteLine(sb.ToString());

            return sb.ToString().Replace(",",".");

        }

    }

}
