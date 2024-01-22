using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {

        private List<Account> _accounts;

        public Customer() { }

        public string CreateSavingsAccount(string name)
        {
            throw new NotImplementedException();
        }

        public string CreateCurrentAccount(string name)
        {
            throw new NotImplementedException();
        }

        public string GenerateStatement()
        {
            throw new NotImplementedException();
        }

        public string Deposit(string account, decimal amount) 
        { 
            throw new NotImplementedException(); 
        }

        public string Withdraw(string account, decimal amount) 
        {  
            throw new NotImplementedException(); 
        }
    }
}
