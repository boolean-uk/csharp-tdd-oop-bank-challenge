using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class Managment
    {
        private List<Customer> _customer;
        internal Managment() 
        { 
            this._customer = new List<Customer>();
        }

        internal bool AddCustomer(Customer customer)
        {
            try
            {
                _customer.Add(customer);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            
        }

        internal List<Customer> GetCustomer() 
        { 
            return _customer;
        }
    }
}
