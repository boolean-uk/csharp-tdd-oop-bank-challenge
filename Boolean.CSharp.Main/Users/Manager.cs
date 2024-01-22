using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Manager : IUser
    {
        private string _name;
        private List<IAccount> _accounts = new List<IAccount>();

        public Manager(string name)
        {
            _name = name;
        }

        public List<IAccount> GetAccounts()
        {
            return new List<IAccount>(_accounts);
        }

        public string GetName()
        {
            return _name;
        }
    }
}
