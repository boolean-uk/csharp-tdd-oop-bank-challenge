using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.TransactionManagement
{
    public interface ITransactionManager
    {
        public void AddTransaction(ITransaction transaction);
        public List<ITransaction> GetTransactions();
        public decimal CalculateBalance();
    }
}
