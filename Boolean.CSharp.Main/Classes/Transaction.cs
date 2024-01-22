using Boolean.CSharp.Main.enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TransactionStatus = Boolean.CSharp.Main.enums.TransactionStatus;

namespace Boolean.CSharp.Main.Classes
{
    public class Transaction : ITransaction
    {
        private Guid _id;
        private TransactionType _type;
        private TransactionStatus _status;
        private DateTime _date;
        private decimal _amount;
        private decimal _newBalance;
        private decimal _oldBalance;

        public Guid Id { get => _id;  }
        public TransactionType Type { get => _type; }
        public TransactionStatus Status { get => _status; set => _status = value; }
        public DateTime Date { get => _date;  }
        public decimal Amount { get => _amount; set => _amount = value; }
        public decimal NewBalance { get => _newBalance; set => _newBalance = value; }
        public decimal OldBalance { get => _oldBalance; set => _oldBalance = value; }

        public Transaction(decimal amount, decimal oldBalance, TransactionType type)
        {
            _id = Guid.NewGuid();
            _type = type;
            Status = TransactionStatus.Approved;
            _date = DateTime.Now;
            Amount = amount;
            OldBalance = oldBalance;
            if(type == TransactionType.Debit)
            {
                NewBalance = OldBalance - Amount;
            }
            else
            {
                NewBalance = OldBalance + Amount;
            }



        }
    }
}
