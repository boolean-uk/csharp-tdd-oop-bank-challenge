using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main.Objects
{
    public class Withdraw : ITransaction
    {
        private int _id;
        private DateTime _date;
        private TransactionStatus _status;
        private TransactionType _type;
        private double _amount;
        private double _newBalance;
        private double _oldBalance;

        public Withdraw(TransactionStatus status, double amount, double newBalance, double oldBalance)
        {
            _id += 1;
            _date = DateTime.UtcNow;
            _type = TransactionType.Withdraw;
            _status = status;
            _amount = amount;
            _newBalance = newBalance;
            _oldBalance = oldBalance;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public DateTime Date { get { return _date; } }
        public TransactionType Type { get { return _type; } set { _type = value; } }
        public TransactionStatus Status { get { return _status; } set { _status = value; } }
        public double Amount { get { return _amount; } set { _amount = value; } }
        public double NewBalance { get { return _newBalance; } set { _newBalance = value; } }
        public double OldBalance { get { return _oldBalance; } set { _oldBalance = value; } }
    }
}
