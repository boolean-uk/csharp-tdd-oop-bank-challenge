using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Manager : User
    {
        public Manager(string name) : base(name) 
        {
            Admin = true;
            this.Name = name;
        }
    }
}
