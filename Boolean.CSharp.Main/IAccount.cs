using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        string AccountName { get; }
        decimal Balance { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        string GenerateStatement();
    }
}