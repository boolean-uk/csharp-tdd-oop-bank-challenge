using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class CustomerUser : IUser
    {
        List<ABankAccount> _accounts;

        public CustomerUser() 
        {
            _accounts = new List<ABankAccount>();
        }

        public string CreateAccount(ABankAccount account)
        {
            if (account != null)
            {
                _accounts.Add(account);
                return "New Account has been made";
            }
            return "Error, something went wrong and we cant make your account";
        }

        public bool Withdraw(double money, ABankAccount account)
        {
            throw new NotImplementedException();
        }

        public double Deposit(double money, ABankAccount account) 
        {
            throw new NotImplementedException(); 
        }

        public int GenerateStatement()
        {
            throw new NotImplementedException();
        }

        public BankStatement RequestOverdraft(double money) 
        {
            throw new NotImplementedException();
        }
    }
}
