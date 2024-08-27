using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Current : Account
    {

        Customer _customer;

        public Current(Branch branch, Customer customer, string accountnr) : base(branch, accountnr)
        {
            this._customer = customer;
        }


        public double GetBalance()
        {
            double debit = 0;
            double credit = 0;
            foreach (Transaction t in Transactions)
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
