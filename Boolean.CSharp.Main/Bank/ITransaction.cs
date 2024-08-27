using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Bank
{
    public interface ITransaction
    {
        decimal Amount { get; }
        DateTime Date { get; }
    }
}
