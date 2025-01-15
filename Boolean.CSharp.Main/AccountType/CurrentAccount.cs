using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Test;

namespace Boolean.CSharp.Main.AccountType
{
    public class CurrentAccount : IAccount
    {
        public List<Transaction> transactions { get; set; }
        public Customer customer { get; set; }
        public double balance { get; set; }
        public double lowerBalanceLimit { get; set; }

        public CurrentAccount(Customer customer)
        {
            this.transactions = new List<Transaction>();
            this.customer = customer;
            this.balance = 0;
            this.lowerBalanceLimit = 0;
        }

        public double deposit(double amount)
        {
            if (amount > 0)
            {
            this.balance += amount;
                transactions.Add(new Transaction(amount));
            }
            return this.balance;
        }

        public double withdraw(double amount)
        {
            if(this.balance-lowerBalanceLimit >= amount && amount > lowerBalanceLimit)
            {
                this.balance -= amount;
                transactions.Add(new Transaction(-amount));
            }
            return this.balance;
        }
        public string transactionListToString()
        {
            double total = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0,-20}{1,15}{2,15}{3,15}", "date", "|| credit", "|| debit", "|| balance \n");
            foreach (Transaction t in transactions)
            {
                total = total + t.amount;
                sb.AppendFormat("{0,-20}{1,12}{2,16}{3,13}", t.date, $"|| {(t.amount > 0 ? t.amount : "   ")}", $"||{(t.amount < 0 ? t.amount : "    ")}", $"|| {total} \n");
            }

            return sb.ToString();
        }

    }
}
