using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankBranch
    {
        public int Id { get; set; }
        public List<IPerson> customers { get; set; } = new List<IPerson>();

        public BankBranch(int id)
        {
            this.Id = id;
        }

        //Needs to check if customer exists in branch, otherwise create new customer
        public bool AddCustomer(IPerson customer1)
        {
            if (customers.Contains(customer1))
            {
                return false;
            }
            customers.Add(customer1);
            return true;
        }

        public List<IPerson> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
