using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(int branch, string phonenr,
            ISMSProvider smsprovider, IStatement statementbuilder) :
            base(branch, phonenr, statementbuilder, smsprovider)
        {
        }
    }
}
