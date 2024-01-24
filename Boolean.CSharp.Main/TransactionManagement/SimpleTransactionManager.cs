﻿using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.TransactionManagement
{
    public class SimpleTransactionManager : ITransactionManager
    {
        private List<ITransaction> transactions;


        public SimpleTransactionManager()
        {
            this.transactions = new List<ITransaction>();
        }
        public void AddTransaction(ITransaction transaction)
        {
            transactions.Add(transaction);
        }

        public List<ITransaction> GetTransactions()
        {
            return GetTransactions(DateTime.MinValue, DateTime.Now);
        }

        public List<ITransaction> GetTransactions(DateTime startTime, DateTime endTime)
        {
            if (this.transactions.Count == 0) return new List<ITransaction>();
            return transactions.Where(t => t.Date >= startTime && t.Date <= endTime).ToList();
        }

    }
}