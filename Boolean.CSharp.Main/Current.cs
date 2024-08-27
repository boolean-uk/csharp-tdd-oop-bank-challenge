using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Current : Account
    {
        private double _balance = 0;

        Customer _customer;

        public Current(Customer customer, Branch branch, string accountnr, string type, double balance) : base(branch, accountnr, type, balance)
        {
            this._customer = customer;
        }

        public double Balance { get => _balance; set => _balance = value; }

        
    }
}
