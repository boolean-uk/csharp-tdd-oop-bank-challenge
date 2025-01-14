using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.Class
{
    public class Transaction
    {
        private decimal _balance;
        private TransactionType _type;
        private DateTime _transactionDate;

        public Transaction(decimal balance, TransactionType type) 
        {
            _balance = balance;
            _type = type;
            _transactionDate = DateTime.Now;
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime TransactionDate { get => _transactionDate; set => _transactionDate = value; }
        public TransactionType Type { get => _type; set => _type = value; }
        public decimal Balance { get => _balance; set => _balance = value; }

    }
}
