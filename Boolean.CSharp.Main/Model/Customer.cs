using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{

    internal class Customers
    {

        private string _name;
        private List<IAccount> _accounts;
        internal Customers(string name) 
        { 
            this._name = name;
            this._accounts = new List<IAccount>();
        }

        internal string Name { get { return _name; } }
        internal List<IAccount> Accounts { get { return _accounts; } }

    }
}
