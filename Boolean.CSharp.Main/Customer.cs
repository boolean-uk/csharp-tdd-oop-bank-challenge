using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer : IPerson
    {
        public string Name { get; set; }
        public List<IAccount> Accounts { get; set; } = new List<IAccount>();
        public bool isManager { get; } = false;
        
        public Customer(string name) : base(name) 
        {
            this.Name = name;
        }
    }
}
