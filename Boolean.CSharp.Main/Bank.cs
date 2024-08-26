using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private int customers = -1;
        private double overDraftLimit = 0;
        public Bank() { }

        public bool CreateAccount(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool CreateCustomer(Customer customer)
        {
            if(customer.customerId == -1)
            {
                //new customer
                customers++;
                customer.customerId = customers;
                return true;
            }
            return false;
        }

        public double GetOverdraftLimit()
        {
            return overDraftLimit; 
        }

        public void SetOverdraftLimit(Manager manager)
        {
            overDraftLimit = manager.overDraftLimit;
        }
        
    }
}
