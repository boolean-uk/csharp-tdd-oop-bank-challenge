using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {

        public decimal OverdraftLimit { get; set; }
        public CurrentAccount(string firstName, string lastName, Branch branch, decimal balance = 0)
            : base(firstName, lastName, branch)

        {
            OverdraftLimit = 1000;

        }

    }
}

