using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        public Customer(double funds)
        {
            this.funds = funds;
        }
        public double funds;
        public int customerId = -1;
        public List<int> accounts = new List<int>();
    }
}
