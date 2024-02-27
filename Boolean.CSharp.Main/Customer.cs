using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Password { get; private set; }
        public Customer(string name, string address, string password) 
        {
            Name = name;
            Address = address; 
            Password = password;
        }

    }
}
