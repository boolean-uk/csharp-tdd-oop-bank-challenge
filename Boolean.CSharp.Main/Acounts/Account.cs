using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Acounts
{
    public abstract class Account
    {
        public decimal Balance { get; set; } = 0;

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Branch yourBranch { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                this.Balance += amount;
            }
            else
            {
                Console.WriteLine("Cant deposit a value like that");
            }
        }


    }
}
