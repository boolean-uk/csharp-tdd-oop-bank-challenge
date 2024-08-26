using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Acounts
{
    public class CurrentSavingsAccount : Account
    {
        public void Deposit(decimal amount)
        {
            if (amount > 0)
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
