using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string name, Branch inputBranch) {
            accountNumber = Guid.NewGuid();
            accountName = name;
            branch = inputBranch;
        }
    }
}
