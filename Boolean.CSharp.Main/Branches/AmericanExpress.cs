using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Branches
{
    public class AmericanExpress : IBranch
    {
        public string branchName { get; set; } = string.Empty;
        public double maxCreditLimit { get; set; } = double.MaxValue;
        public AmericanExpress()
        {
            this.branchName = "American Express";
            this.maxCreditLimit = 2000.00;
        }
    }
}
