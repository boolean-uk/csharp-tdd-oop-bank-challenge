using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Current : Account
    {
        //private List<Transaction> transactions = new List<Transaction>();

        Customer _customer;
        //Transaction _transaction;

        public Current(Branch branch, Customer customer, string accountnr) : base(branch, accountnr)
        {
            this._customer = customer;
        }

        //public List<Transaction> Transactions { get => transactions; set => transactions = value; }

        public double GetBalance()
        {
            double debit = 0;
            double credit = 0;
            foreach (Transaction t in Transactions) //This is skipping, why? Corrected to get it from the abstract class
            {
                if (t.Debit != null)
                {
                    debit += (double)t.Debit;
                }
                if (t.Credit != null)
                {
                    credit += (double)t.Credit;
                }
            }
            return debit - credit;
        }
    }
}
