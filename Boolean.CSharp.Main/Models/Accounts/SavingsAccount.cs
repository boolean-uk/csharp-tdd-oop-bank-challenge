using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models.Accounts
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(Branch branch, string phoneNumber) : base(branch, phoneNumber)
        {

        }
    }
}
