using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
//using Boolean.CSharp.Main;


namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        public List<Transaction> Transactions { get; } = new List<Transaction>();


    }


}
