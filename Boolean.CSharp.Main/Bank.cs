using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Bank
    {
        public string Name { get; set; }
        public double emergencyFund { get; set; }
        List<Branch> branches = new List<Branch>();
       public Bank(string name, double emergencyFund) 
       {
            this.Name = name;
            this.emergencyFund = emergencyFund;
       }



    }
}
