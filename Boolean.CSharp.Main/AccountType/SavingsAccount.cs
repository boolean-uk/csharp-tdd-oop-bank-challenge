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
            this.balance = 0;
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
            if(this.balance >= amount)
            {
                this.balance -= amount;
                transactions.Add(new Transaction(-amount));
            }
            return this.balance;
        }
    }
}
