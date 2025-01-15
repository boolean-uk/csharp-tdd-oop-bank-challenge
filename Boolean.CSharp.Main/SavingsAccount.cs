using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        string accountid;
        double balance = 0;
        string type = "savings account";
        public SavingsAccount() 
        {
            Guid newGuid = Guid.NewGuid();
            this.accountid = newGuid.ToString();
        }

        public override double Balance { get => balance; set => balance= value; }
        public override string Accountid { get => accountid; set => accountid=value; }

        public string Type { get => type; }
    }
}
