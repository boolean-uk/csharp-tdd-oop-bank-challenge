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
        public Customer customer { get;  set; }
        public double balance { get; set; }

        public SavingsAccount(Customer customer)
        {
            this.customer = customer;
        }

        public double deposit(double amount)
        {
            // TODO
            return 0.0;
        }

        public double withdraw(double amount)
        {
            // TODO
            return 0.0;
        }
    }
}
