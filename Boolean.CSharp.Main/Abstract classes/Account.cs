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
        public BankTypes Type { get; set; }
        public string Owner { get; set; }

        //string Branch { get; set; }
        public Branches Branch { get; set; }

        public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();

        private double _balance { get; set; } = 0;

        public double Balance { get { return _balance; } }

        public string GenerateStatement()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Transaction transaction in TransactionHistory)
            {
                sb.Append($"{transaction.date}\t||");

                if(transaction.credit == 0)
                {
                    sb.Append($"\t\t||");
                }
                else
                {
                    sb.Append($"{transaction.credit}\t\t||");
                }

                if (transaction.debit == 0)
                {
                    sb.Append($"\t\t||");
                }
                else
                {
                    sb.Append($"{transaction.debit}\t\t||");
                }

                sb.AppendLine($"{transaction.balance}");
            }

            return sb.ToString(); 
        }

        public bool AddBalance(double amount)
        {
            _balance += amount;
            return true;
        }

        public bool RemoveBalance(double amount)
        {
            _balance -= amount;
            return true;
        }

        public double CalculateBalance()
        {
            double totalBalance = 0;
            foreach (Transaction transaction in TransactionHistory)
            {
                totalBalance -= transaction.debit;
                totalBalance += transaction.credit;
            }
            return totalBalance;
        }
    }
}
