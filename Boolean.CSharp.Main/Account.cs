using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        public double balance { get; set; } = 0;
        public ICollection<Transactions> _transactions { get { return _transactions; } }

        public double getBalance()
        {
            return this.balance;
        }
        public double deposit(double amount)
        {
            this.balance += amount;

            return this.balance;
        }

        public double withdraw(double amount)
        {
            if (this.balance < amount)
            {
                Console.WriteLine("Your balance is to low, change amount!");
                return this.balance;
            }

            this.balance -= amount;
            return this.balance;
        }
    }
}
