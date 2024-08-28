using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Savings : Account
    {
        public Savings(Branch branch, Customer customer, string accountnr) : base(branch, customer, accountnr)
        {
        }
    }
}
