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
        private string number = null;

        public string Number { get => number; }

        public Customer(string v, string? number = null)
        {
            this._name = v;
            this.number = number;
        }
    }
}
