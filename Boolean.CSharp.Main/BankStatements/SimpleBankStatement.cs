using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankStatements
{
    public class SimpleBankStatement : IBankStatement
    {
        public BankAccount Account { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SimpleBankStatement(BankAccount account)
        {
            throw new NotImplementedException();
        }

        public string GenerateStatement()
        {
            throw new NotImplementedException();
        }
    }
}
