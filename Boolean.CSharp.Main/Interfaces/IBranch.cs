using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IBranch
    {
        public string name { get; set; }
        public decimal allowedOverdraft {  get; set; }

        public decimal GetAllowedOverdraft();
    }
}
