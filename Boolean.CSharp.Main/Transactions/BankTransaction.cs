using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Transactions
{
    public class BankTransaction : ITransaction
    {
        private Guid _id;
        private DateTime _date = DateTime.Now;
        private double _oldbalance;
        private double _newbalance;
        private double _amount;
        private TransactionType _type;

        public Guid Id { get { return _id; } }
        public TransactionType Type { get { return _type; } }
        public DateTime Date { get { return _date; } }
        public double Amount { get { return _amount; } }
        public double NewBalance { get { return _newbalance; } }
        public double OldBalance { get { return _oldbalance; } }

        public BankTransaction(TransactionType type, double oldB, double amount)
        {
            _id = Guid.NewGuid();
            _type = type;
            _date = DateTime.Now;
            _amount = amount;
            _oldbalance = oldB;
            switch (_type)
            {
                case TransactionType.Credit:
                    _newbalance = oldB + amount; break;
                case TransactionType.Debit:
                    _newbalance = oldB - amount; break;
            }
        }
    }
}
