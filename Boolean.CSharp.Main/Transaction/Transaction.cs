using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transaction
{
    public class Transaction
    {
        private DateTime _dateTime;
        private decimal _credit;
        private decimal _debit;
        private decimal _newBalance;

        public Transaction(DateTime dateTime, decimal credit, decimal debit, decimal newBalance)
        {
            this.dateTime = dateTime;
            this.credit = credit;
            this.debit = debit;
            this.newBalance = newBalance;

        }

        public DateTime dateTime { get { return _dateTime; } set {  _dateTime = value; } }
        public decimal credit { get { return _credit; } set { _credit = value; } }
        public decimal debit { get { return _debit; } set { _debit = value; } }
        public decimal newBalance { get { return _newBalance; } set { _newBalance = value; } }

    }
}
