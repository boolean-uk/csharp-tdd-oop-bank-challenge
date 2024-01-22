using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concretes
{
    public class Customer : ICustomer
    {
        public void AddCurrentAccount()
        {
            throw new NotImplementedException();
        }

        public void AddSavingsAccount()
        {
            throw new NotImplementedException();
        }

        public List<IAccount> GetAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
