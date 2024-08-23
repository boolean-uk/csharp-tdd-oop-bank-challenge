using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        string AccountNumber { get; }
        decimal Balance { get; }
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        List<ITransaction> GetTransactions();
        string GenerateStatement();
    }
}
