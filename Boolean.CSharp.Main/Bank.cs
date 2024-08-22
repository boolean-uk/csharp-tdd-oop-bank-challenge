using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        public string Name { get; set; }
        public BankFillial BankFillial { get; set; }
        

        public IAccount CreateAccount(IPerson person, string accountType)
        {
            return null;
        }

        public bool Deposit(decimal amount, IAccount account)
        {
            return false;
        }

       
    }
}
