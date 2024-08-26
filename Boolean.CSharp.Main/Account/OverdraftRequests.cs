using Boolean.CSharp.Main.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Account
{
    public static class OverdraftRequests
    {
        public static List<Tuple<BankAccount, BankTransaction>> overdraftRequests = new List<Tuple<BankAccount, BankTransaction>>();
    }
}
