using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Current : Account
    {
        private string _accountnr;
        private string _type;
        //private string _branch;
        //private string _ownername;
        private double _balance = 0;

        Customer _customer;
        Branch _branch;

        public Current(Customer customer, Branch branch, string accountnr, string type, double balance) : base(branch, accountnr, type, balance)
        {
            this._customer = customer;
        }

        //public override void CreateAccount()
        //{
        //    throw new NotImplementedException();
        //}

        public string AccountNr { get => _accountnr; set => _accountnr = value; }

        public string Type { get => _type; set => _type = value; }

        //public string Branch { get => _branch; set => _branch = value; }

        //public string OwnerName { get => _ownername; set => _ownername= value; }

        public double Balance { get => _balance; set => _balance = value; }

        
    }
}
