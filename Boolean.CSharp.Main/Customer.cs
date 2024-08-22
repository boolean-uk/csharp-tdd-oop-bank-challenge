using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        public List<IAccount> accounts {  get; set; }  = new List<IAccount>();

        public bool CreateAccount(AccountType type)
        {
            switch (type)
            {
                case AccountType.Current:
                    IAccount account = new CurrentAccount();
                    accounts.Add(account);
                    break;
            }

            return true;
        }
    }
}
