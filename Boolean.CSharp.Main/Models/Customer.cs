using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Models.Accounts;

namespace Boolean.CSharp.Main.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<IAccount> Accounts { get; set; }
        public IAccount CreateAccount(AccountType current, Branch oslo)
        {
            throw new NotImplementedException();
        }
    }
}
