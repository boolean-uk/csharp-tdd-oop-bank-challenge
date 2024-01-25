using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Transactions;

namespace Boolean.CSharp.Main.Users
{
    public class Customer
    {

        public Guid CustomerId { get; set; }
        public string name { get; set; }


        public Customer(string Name) 
        {
            this.CustomerId = Guid.NewGuid();
            this.name = Name;
        }

        

    }
}
