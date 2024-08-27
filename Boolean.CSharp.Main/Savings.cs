using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Savings : Account
    {
        Customer _customer;
        public Savings(Branch branch, List<Transaction> transactions, Customer customer, string accountnr, string type, double balance) : base(branch, transactions, accountnr, type, balance)
        {
            this._customer = customer;
        }
    }
}
