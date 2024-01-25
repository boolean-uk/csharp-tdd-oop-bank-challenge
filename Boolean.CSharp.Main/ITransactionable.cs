using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface ITransactionable
    {
        bool Deposit(double amount);
        bool Withdraw(double amount);
        string GenerateStatement();
    }
}
