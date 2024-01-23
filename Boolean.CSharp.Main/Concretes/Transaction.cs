using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concretes
{
    public class Transaction : ITransaction
    {
        private double _amount;
        private double _balance;
        private DateTime _created;
        public Transaction(double amount, double balance) 
        { 
            _amount = amount;
            _balance = balance;
            _created = DateTime.UtcNow;
        }

        public Tuple<DateTime, double, double> GetDetails()
        {
            return Tuple.Create(_created, _amount, _balance);
        }
    }
}
