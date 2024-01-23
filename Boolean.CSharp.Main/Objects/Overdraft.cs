using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Objects
{
    public class Overdraft : ITransaction
    {

        private int _id;
        private DateOnly _date;
        private TransactionStatus _status;
        private TransactionType _type;
        private double _amount;
        private double _newBalance;
        private double _oldBalance;

        public Overdraft(TransactionStatus status, double amount, double newBalance, double oldBalance)
        {
            _id += 1;
            _date = DateOnly.FromDateTime(DateTime.Now);
            _type = TransactionType.Withdraw;
            _status = status;
            _amount = amount;
            _newBalance = newBalance;
            _oldBalance = oldBalance;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public DateOnly Date { get { return _date; } }
        public TransactionType Type { get { return _type; } set { _type = value; } }
        public TransactionStatus Status { get { return _status; } set { _status = value; } }
        public double Amount { get { return _amount; } set { _amount = value; } }
        public double NewBalance { get { return _newBalance; } set { _newBalance = value; } }
        public double OldBalance { get { return _oldBalance; } set { _oldBalance = value; } }
    }
}
