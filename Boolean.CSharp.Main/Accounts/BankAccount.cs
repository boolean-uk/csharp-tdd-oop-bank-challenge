using Boolean.CSharp.Main.TransactionManagement;
using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class BankAccount
    {
        private ITransactionManager transactions;

        public BankAccount(ITransactionManager transactionManager)
        {
            this.transactions = transactionManager;
        }
        public void ApplyTransaction(ITransaction transaction)
        {
            transactions.AddTransaction(transaction);
        }

        public decimal Balance { get => transactions.CalculateBalance(); }
        public ITransactionManager Transactions { get => transactions; }
    }
}
