using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime _date;
        private decimal _amount;
        private decimal _credit;
        private decimal _debit;

        public Transaction(DateTime date, decimal amount, decimal credit, decimal debit)
        {
            _date = DateTime.Now;
            _amount = amount;
            _credit = credit;
            _debit = debit;
        }
    }
}
