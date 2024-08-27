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
        private string _type;
        //private string _branch;
        //private string _ownername;
        private double _balance = 0;
        private List<Transaction> _transactions = new List<Transaction>();

        Branch _branch;

        public Account(Branch branch, string accountNr, string type, double balance)
        {
            _accountnr = accountNr;
            _type = type;
            _branch = branch;
            //_ownername = ownerName;
            _balance = balance;
        }

        public string AccountNr { get => _accountnr; set => _accountnr = value; }
        public string Type { get => _type; set => _type = value; } //Very much feeling this may be redundant, seeing as I aldready have classes for each account type
        public double Balance { get => _balance; set => _balance = value; }
      
        public List<Transaction> Transactions { get => _transactions; set => _transactions = value; }

        public Branch Branch { get => _branch; set => _branch = value; }

    }
}
