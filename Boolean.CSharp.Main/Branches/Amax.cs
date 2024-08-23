using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Branches
{
    public class Amax : IBranch
    {
        public string branchName { get; set; } = string.Empty;
        public double maxCreditLimit { get; set; } = double.MaxValue;
        public Amax()
        {
            this.branchName = "Amax";
            this.maxCreditLimit = 1500.00;
        }
    }
}
