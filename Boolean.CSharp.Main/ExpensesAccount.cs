using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class ExpensesAccount : Account
    {
        public ExpensesAccount(int branchcode, string customerPhoneNumber) : base(branchcode, customerPhoneNumber)
        {
        }
    }
}
