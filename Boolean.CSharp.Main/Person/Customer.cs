using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Person
{
    public class Customer : Person
    {
        private List<IAccount> _account = new List<IAccount>();

        public List<IAccount> accounts { get { return _account; } }


        public Customer(string name, int id) : base(name, id) { }

        public object createAccount(AccountType current, string accountNumber)
        {
            throw new NotImplementedException();
        }



        
    }
}
