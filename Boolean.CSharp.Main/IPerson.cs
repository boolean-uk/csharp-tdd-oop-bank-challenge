using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class IPerson
    {
        public string Name { get; set; }
        public List<IAccount> Accounts { get; set; } = new List<IAccount>();
        public bool isManager { get; set; }

        public IPerson(string name)
        {
            this.Name = name;
        }

        public void AddAccount(IAccount account)
        {
            foreach (var item in Accounts)
            {
                if(!item.AccountNumber.Equals(account.AccountNumber))
                {
                    Accounts.Add(account);
                }
            }
        }

    }
}
