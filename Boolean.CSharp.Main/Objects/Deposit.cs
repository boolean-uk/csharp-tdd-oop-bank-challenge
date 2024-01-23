using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Boolean.CSharp.Main.Objects
{
    public class Deposit : ITransaction
    {
        private int _id;
        private DateOnly _date;
        private TransactionStatus _status;
        private TransactionType _type;
        private double _amount;
        private double _newBalance;
        private double _oldBalance;

        public Deposit(TransactionStatus status, double amount, double newBalance, double oldBalance)
        {
            _id += 1;
            _type = TransactionType.Deposit;
            _date = DateOnly.FromDateTime(DateTime.Now);
            _status = status;
            _amount = amount;
            _newBalance = newBalance;
            _oldBalance = oldBalance;
        }


        public int Id { get { return _id; } set { _id = value; } }
        public DateOnly Date { get { return _date; } }
        public TransactionStatus Status { get { return _status; } set { _status = value; } }
        public TransactionType Type { get { return _type; } set {  _type = value; } }
        public double Amount { get { return _amount; } set { _amount = value; } }
        public double NewBalance { get { return _newBalance; } set { _newBalance = value; } }
        public double OldBalance { get { return _oldBalance; } set { _oldBalance = value; } }
    }
}
