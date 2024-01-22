using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Transations;

namespace Boolean.CSharp.Main.Users
{
    public class Customer
    {

        public Guid CustomerId { get; set; }
        public string name { get; set; }

        public List<BankTransaction> CustomerTransactionHistories;

        public Customer(string Name) 
        {
            this.CustomerId = Guid.NewGuid();
            this.name = Name;
        }   

    }
}
