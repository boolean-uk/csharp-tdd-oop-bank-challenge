using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Branches
{
    public class Benevolent : IBranch
    {
        public string name { get; set; }
        public decimal allowedOverdraft { get; set; }

        public Benevolent()
        {
            this.name = "Benevolent";
            this.allowedOverdraft = 1000;
        }

        public decimal GetAllowedOverdraft()
        {
            return this.allowedOverdraft;
        }
    }
}
