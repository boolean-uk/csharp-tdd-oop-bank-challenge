using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Customers
{
    public class Carl : ICustomer
    {
        public string name { get; set; }

        public Carl()
        {
            this.name = "Carl";
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
