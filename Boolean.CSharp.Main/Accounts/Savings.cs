using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class Savings : Account
    {
       public Savings(Branch branch) 
        {
            this.branch = branch;
        }
    }
}
