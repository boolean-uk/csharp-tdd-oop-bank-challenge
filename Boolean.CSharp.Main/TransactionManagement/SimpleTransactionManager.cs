using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.TransactionManagement
{
    public class SimpleTransactionManager : ITransactionManager
    {
        public void AddTransaction(ITransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void GetTransactions(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
