using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Branches
{
    public class MasterCard : IBranch
    {
        public string name { get; set; }
        public decimal allowedOverdraft { get; set; }

        public MasterCard()
        {
            this.name = "MasterCard";
            this.allowedOverdraft = 200;
        }

        public decimal GetAllowedOverdraft()
        {
            return this.allowedOverdraft;
        }
    }
}
