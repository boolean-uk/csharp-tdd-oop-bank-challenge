using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Models
{
    public class AccountManager
    {
        public Dictionary<int, Accounts.Account> Accounts { get; set;}

        public AccountManager() 
        {
            Accounts = new Dictionary<int, Accounts.Account>();
        }

        public int AddCurrent(Branch AssociatedBranch, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public int AddSavings(Branch AssociatedBranch, string phoneNumber)
        {
            throw new NotImplementedException();
        }

    }
}
