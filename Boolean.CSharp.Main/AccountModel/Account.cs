using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.AccountModel
{
    public class Account
    {
        public string Name;
        public double Balance;
        public int FreeWithdrawals;

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if((Balance - amount) < 0)
            {
                Console.WriteLine("You don't have enough to withdraw this amount.");
            } else
            {
                Balance -= amount;
                FreeWithdrawals--;
            }
        }
    }
}
