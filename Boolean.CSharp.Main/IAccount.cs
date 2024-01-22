using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        public void Deposit(Transaction transaction);
        public void Withdraw(Transaction transaction);
        public void PrintStatement();
    }
}
