using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Extensions
{
    public class Bank
    {
        public string Name { get; set; }
        public decimal EmergencyFund { get; set; }
        public List<Branch> Branches { get; set; } = new List<Branch>();

        public Bank(string name, decimal funds)
        {
            Name = name;
            EmergencyFund = funds;
        }

        public void addBranch(Branch branch)
        {
            Branches.Add(branch);
        }

        public List<Branch> getBranches()
        {
            return Branches;
        }

        public decimal moneyLeftInFund()
        {
            return EmergencyFund;
        }
    }
}
