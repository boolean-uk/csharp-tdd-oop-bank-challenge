using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class Customer : ICustomer
    {
        private string _name;

        public Customer(string v)
        {
            this._name = v;
        }
    }
}
