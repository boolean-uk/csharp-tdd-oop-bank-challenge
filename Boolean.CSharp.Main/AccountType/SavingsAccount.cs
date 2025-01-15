using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Test;

namespace Boolean.CSharp.Main.AccountType
{
    public class SavingsAccount : IAccount
    {
        public List<Transaction> transactions { get; set; }
        public Customer customer { get; set; }
        public double balance { get; set; }

        public SavingsAccount(Customer customer)
        {
            this.transactions = new List<Transaction>();
            this.customer = customer;
            this.balance = transactions.Sum(t => t.amount);
        }

        public double deposit(double amount)
        {
            if (amount > 0)
            {
                transactions.Add(new Transaction(amount));
                this.balance = transactions.Sum(t => t.amount);

            }
            return this.balance;
        }

        public double withdraw(double amount)
        {
            if(this.balance >= amount)
            {
                transactions.Add(new Transaction(-amount));
                this.balance = transactions.Sum(t => t.amount);
            }
            return this.balance;
        }

        public string transactionListToString()
        {
            double total = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0,-25}{1,30}{2,30}{3,30}", "date", "|| credit", "|| debit", "|| balance");
            foreach (Transaction t in transactions)
            {
                total = total + t.amount;
                sb.AppendFormat("{0,-25}{1,30}{2,30}{3,30}", t.date, t.amount > 0 ? t.amount : "", t.amount < 0 ? t.amount : "", total);
            }

            return sb.ToString();
        }
    }
}
