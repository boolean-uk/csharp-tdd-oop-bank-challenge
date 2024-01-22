using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private List<Account> accounts;
        private string name;
        public Customer(string name) 
        {
            this.name = name;
            accounts = new List<Account>();
        }
    }
}
