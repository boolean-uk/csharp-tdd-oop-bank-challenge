using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class CurrentAccount : AccountBase
    {
        public CurrentAccount(string accountname, BankStatementBuilder bankStatementBuilder) : base(accountname, bankStatementBuilder)
        {
        }
    }
}
