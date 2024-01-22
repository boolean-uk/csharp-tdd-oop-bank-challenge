using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public class TransactionManager : IBankTransaction
    {
        private List<Tuple<DateTime, decimal>> _history = new List<Tuple<DateTime, decimal>>();

        public bool AddDepositTransaction(decimal amount)
        {
            throw new NotImplementedException();
        }

        public bool AddWithdrawTransaction(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void PrintTransactions(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
