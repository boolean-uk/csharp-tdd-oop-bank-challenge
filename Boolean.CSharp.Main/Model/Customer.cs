using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{

    public class Customer
    {

        private string _name;
        private List<IAccount> _accounts;
        public Customer(string name) 
        { 
            this._name = name;
            this._accounts = new List<IAccount>();
        }

        public string Name { get { return _name; } }
    }
}
