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
        public bool isManager { get; }

        public IPerson(string name)
        {
            this.Name = name;
        }

        public void AddAccount(IAccount account)
        {
            Accounts.Add(account);

        }

    }
}
