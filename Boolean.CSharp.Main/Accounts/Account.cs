using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        private Guid _accountId = Guid.NewGuid();
        private double _balance = 0;
        
        


        public Guid AccountId { get { return _accountId; } set { _accountId = value; } }
        public double Balance { get { return _balance; } set { _balance = value; } }
        
        
       

        public double deposit(double amount)
        {
            Balance += amount;
            return Balance;
        }

        public double withdraw(double amount)
        {
            if(amount > Balance) 
            {
                Balance -= amount;
            }
            return Balance;
            
        }

        
           

    }
}
