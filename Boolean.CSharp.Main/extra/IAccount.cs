using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.extra
{
    public interface IAccount
    {
        public double GetBalance();
        public void Deposit(double amount);
        public bool Withdraw(double amount);
        public string BankStatement();
    }
}
