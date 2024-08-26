using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Bank
{
    public interface IAccount
    {
        public string AccountType { get; set; }
        public string Branch { get; set; }
    }
}
