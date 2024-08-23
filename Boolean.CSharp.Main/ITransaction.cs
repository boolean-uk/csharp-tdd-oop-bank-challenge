using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface ITransaction
    {
        int Amount { get; set; }
        int BalanceAfterTransaction { get; set; }
        string Type { get; set; }
    }
}
