using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Branches
{
    public class Visa : IBranch
    {
        public string name { get; set; }
        public decimal allowedOverdraft { get; set; }

        public Visa()
        {
            this.name = "Visa";
            this.allowedOverdraft = 150;
        }

        public decimal GetAllowedOverdraft()
        {
            return this.allowedOverdraft;
        }
    }
}
