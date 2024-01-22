using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public abstract class Customer : IUser
    {
        public List<IAccount> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public bool OpenNewAccount(string accountType) 
        {
            throw new NotImplementedException();
        }
    }
}
