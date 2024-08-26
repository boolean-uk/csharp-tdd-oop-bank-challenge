using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class Savings : Account
    {
        public Savings(int customerId, int accountNumber, IBranch branch) : base(customerId, accountNumber, branch)
        {

        }

        public string GenerateStatement()
        {
            throw new NotImplementedException();
        }
    }
}
