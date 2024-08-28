using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private string _name;
        
        public Customer(string name) 
        { 
            this._name = name; 
        }

        public string Name { get => _name; set => _name = value; }
    }
}
