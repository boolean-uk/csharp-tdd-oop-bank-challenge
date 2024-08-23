using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Boolean.CSharp.Main.Model;

namespace Boolean.CSharp.Main.Controler
{
    public class MainControler
    {
        private Managment management;
        public MainControler() { 
            this.management = new Managment();
        }

        internal bool CreateAccount(string AccountName, string SocialSecurityNr)
        {
            Customer? c = management.GetCustomer().FirstOrDefault(propa => propa.CustomerId == SocialSecurityNr);
            if (c == null)
            {
                return false;
            }
            else
            {
                return if(c.CreateAccount(AccountName)) ;
            }
        }

        internal bool CreateCustomer(string customerName, string socialSecurityNr)
        {
            try
            {
                Customer c = new Customer(customerName, socialSecurityNr);
                management.AddCustomer(c);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        } 
    }
}
