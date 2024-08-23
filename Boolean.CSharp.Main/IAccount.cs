using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        decimal Balance { get; set; }

        void Deposit(decimal amount);

        void Withdraw(decimal amount);

        List<ITransaction> GetTransactions();
        string GenerateStatement();
    }
}
