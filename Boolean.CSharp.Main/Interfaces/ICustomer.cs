using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface ICustomer
    {
        public string name { get; set; }

        public string GetName();
    }
}
