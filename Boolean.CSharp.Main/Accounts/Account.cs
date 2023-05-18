using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        public List<Transaction> Transactions { get; set; }
        public decimal Balance { get; set; }

        public Account()
        {
            Transactions = new List<Transaction>();
        }
        public virtual void Deposit(decimal amount)
        {

        }
        public virtual void Withdraw(decimal amount)
        {

        }

        public BankStatement GenerateStatement()
        {
            return new BankStatement();
        }
    }
}
