using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models
{
    public class Bank
    {
        public List<Customer> Customers { get; set; }
        public List<Branch> Branches { get; set; }

        public Bank()
        {
            Customers = new List<Customer>();
            Branches = new List<Branch>();
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
    }
}
