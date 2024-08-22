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
        private Customer(string name) 
        { 
            this._name = name;
            this._accounts = new List<IAccount>();
        }

        private string Name { get { return _name; } }
    }
}
