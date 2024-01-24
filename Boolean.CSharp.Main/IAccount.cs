using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        void Deposit(double amount, DateTime date);
        void Withdraw(double amount, DateTime date);
        string PrintStatement();
        double GetBalance();
       // void RequestOverdraft(double amount);
    }
}