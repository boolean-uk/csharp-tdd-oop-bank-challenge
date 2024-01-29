using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IBankTransaction
    {
        DateTime Date { get; }
        string Type { get; }
        int Amount { get; }
        string Status { get; }
        int NewBalance { get; }
    }
}
