using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        double balance = 0;
        string accountid;
        //string type = "current account";
        bool overdraftable=true;
        double maxOverdraft = -1000;

        public CurrentAccount()
        {
            Guid newGuid = Guid.NewGuid();
            this.accountid = newGuid.ToString();
        }

        public override double Balance { get => balance; set => balance = value; }
        public override string Accountid { get => accountid; set => accountid = value; }

        //public string Type { get => type; } 
        
        public bool Overdraftable { get => overdraftable; set => overdraftable = value; }

        public double MaxOverdraft { get => maxOverdraft;   set => maxOverdraft = value; }





    }
}
