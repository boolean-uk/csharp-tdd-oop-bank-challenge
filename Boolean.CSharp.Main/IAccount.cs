using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        User Owner { get; }
        List<Transaction> Transactions { get; }

        void Deposit(double amount);

        bool Withdraw(double amount, double overdraftAmount);

        double GetBalance();
    }
}
