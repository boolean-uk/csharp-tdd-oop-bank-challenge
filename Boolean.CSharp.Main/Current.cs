using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Current : Account
    {
        public Current(Branch branch, Customer customer, string accountnr) : base(branch, customer, accountnr)
        {

        }
    }
}
