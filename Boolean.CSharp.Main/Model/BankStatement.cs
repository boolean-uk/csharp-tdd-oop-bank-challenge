using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class BankStatement
    {
        private DateTime _date;
        private float _transactionValue;
        private float _balanceAtTime;
        private int _customerID;
        private bool _transactionalAccount;
        private bool _withdraw;
        private Enum _branch;

        public BankStatement(DateTime date, float transactionValue, float balanceAtTime, int customerID, bool transactionalAccount, bool withdraw, Enum branch)
        {
            _date = date;
            _transactionValue = transactionValue;
            _balanceAtTime = balanceAtTime;
            _customerID = customerID;
            _transactionalAccount = transactionalAccount;
            _withdraw = withdraw;
            _branch = branch;
        }

        public DateTime date() { return _date; }
        public float transactionValue() { return _transactionValue; }
        public int customerID() { return _customerID; }
        public float balanceAtTime() { return _balanceAtTime; }
        public bool transactionalAccount() { return _transactionalAccount; }
        public bool withdraw() { return _withdraw; }
        public Enum branch() { return _branch; }
    }
}
