using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Customer
    {

        private string _name;
        public Customer(string name)
        {
            _name = name;
        }


        public IAccount CreateAccount(string v)
        {
            throw new NotImplementedException();
        }
        public string Name { get { return _name; } }
    }
}
