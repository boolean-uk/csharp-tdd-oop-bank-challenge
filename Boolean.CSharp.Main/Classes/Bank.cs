using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class Bank
    {
        public string name;
        public List<BankBranch> branches;

        public Bank(string name)
        {
            this.name = name;
            this.branches = new List<BankBranch>();
        }

        public BankBranch CreateBranch(string location)
        {
            BankBranch b = new BankBranch(location);
            branches.Add(b);
            return b;
        }
    }
}
