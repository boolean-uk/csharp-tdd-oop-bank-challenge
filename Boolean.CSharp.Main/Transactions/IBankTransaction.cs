using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public interface IBankTransaction
    {
        void PrintTransactions(DateTime start, DateTime end);

        bool AddDepositTransaction(decimal amount);

        bool AddWithdrawTransaction(decimal amount);
    }
}
