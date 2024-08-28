using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Boolean.CSharp.Main
{
    public interface ITransaction
    {
        decimal operationAmount { get; }
        decimal beforeAmount { get; }
        decimal afterAmount { get; }
        Operation operation { get; set; }
        decimal GetBalance();

    }
}
