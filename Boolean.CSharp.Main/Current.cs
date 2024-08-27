using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Current : Account
    {
        private List<Transaction> transactions = new List<Transaction>();

        Customer _customer;
        //Transaction _transaction;

        public Current(Customer customer, Branch branch, string accountnr, string type, double balance) : base(branch, accountnr, type, balance)
        {
            this._customer = customer;
        }

        public List<Transaction> Transactions { get => transactions; set => transactions = value; }

        public double GetBalance()
        {
            return 0.0;
        }
    }
}
