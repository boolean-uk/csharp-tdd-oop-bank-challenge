using Boolean.CSharp.Main.Acounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Extensions
{
    public class Branch
    {

        public List<Account> accounts { get; set; } = new List<Account>();
        public string Name { get; set; }

        public Branch(string name)
        {
            Name = name;
        }



        //maybe redundant
        public void AddAccount(Account account)
        {
            account.associatedBranch = this;
            accounts.Add(account);
        }
    }
}
