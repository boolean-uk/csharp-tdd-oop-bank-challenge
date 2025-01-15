using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class AccountAbstract
    {
        public string Name      { get; set; }
        public double Balance   { get; set; }
        public List<Transaction> Transactions {get; set;}

        public AccountAbstract(string name) 
        {
            this.Name = name;
            this.Balance = 0;
            this.Transactions = new List<Transaction>();
        }


        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                return;
            }
            Transaction transaction = new Transaction(DateTime.Now.ToString("dd/MM/yyyy"), amount, 0, Balance);
            Transactions.Add(transaction);
            this.Balance += amount;
        }
        public abstract void Withdraw(double amount);
        public string GenerateReport()
        {
            StringBuilder sb = new StringBuilder();
            string header = string.Format("{0,-15} || {1,-10} || {2,-10} || {3,-10}", "Date", "Credit", "Debit", "Balance");
            sb.AppendLine(header);
            sb.AppendLine(new string('-', 55)); // Adds a separator line

            foreach (Transaction transaction in Transactions)
            {
                sb.AppendLine(string.Format(
                    "{0,-15} || {1,-10} || {2,-10} || {3,-10}",
                    transaction.date,
                    transaction.credit != 0 ? transaction.credit.ToString("F2") : "-", 
                    transaction.debit != 0 ? transaction.debit.ToString("F2") : "-",
                    transaction.balance.ToString("F2")
                ));
            }

            return sb.ToString();
        }

    }

}
