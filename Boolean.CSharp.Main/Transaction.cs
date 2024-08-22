using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime _date;
        
        private double _credit;
        
        private double _debit;
        
        private double _balance;

        public Transaction(DateTime date, double balance, double credit, double debit) 
        { 
            _date = date;
            _balance = balance;
            _credit = credit;
            _debit = debit;
        }
    }
}
