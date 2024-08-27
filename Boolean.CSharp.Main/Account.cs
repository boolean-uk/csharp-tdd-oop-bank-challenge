using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private string _accountnr;
        private double _balance = 0;
        private List<Transaction> _transactions = new List<Transaction>();

        Customer _customer;
        Branch _branch;

        public Account(Branch branch, Customer customer, string accountNr)
        {
            _branch = branch;
            _customer = customer;
            _accountnr = accountNr;
        }

        public string AccountNr { get => _accountnr; set => _accountnr = value; }
        public double Balance { get => _balance; set => _balance = value; }
      
        public List<Transaction> Transactions { get => _transactions; set => _transactions = value; }

        public Branch Branch { get => _branch; set => _branch = value; }

        public Customer Customer { get => _customer; set => _customer = value; }

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
