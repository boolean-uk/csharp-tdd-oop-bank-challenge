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
        private double? _credit;
        private double? _debit;
        private double _newbalance;

        public Transaction(DateTime date, double? credit, double? debit, double newbalance)
        {
            _date = date;
            _credit = credit;
            _debit = debit;
            _newbalance = newbalance;
        }

        public DateTime Date { get => _date; set => _date = value; }
        public double? Credit { get => _credit; set => _credit = value; }
        public double? Debit { get => _debit; set => _debit = value; }
        public double Newbalance { get => _newbalance; set => _newbalance = value; }
    }
}
