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

        public AccountAbstract(string name) 
        {
            this.Name = name;
            this.Balance = 0;
        }


        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                return;
            }
            this.Balance += amount;
        }
        public void Withdraw(double amount)
        {
            if (amount > this.Balance)
            {
                return;
            }
            this.Balance -= amount;
        }
        public void GenerateReport()
        {
            throw new NotImplementedException();
        }

    }
}
