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
        public Customer customer { get; set; }
        public double balance { get; set; }

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
