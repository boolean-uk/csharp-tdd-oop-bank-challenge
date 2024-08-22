using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public abstract class Account
    { 
        public int ID { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }

        //string Branch { get; set; }

        public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();

        public double Balance { get; } = 0;

        public string GenerateStatement()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Transaction transaction in TransactionHistory)
            {
                sb.Append(transaction.date + " || ");
                sb.Append(transaction.credit + " || ");
                sb.Append(transaction.debit + " || ");
                sb.AppendLine(transaction.balance + " ");
            }

            return sb.ToString(); 
        }
    }
}
