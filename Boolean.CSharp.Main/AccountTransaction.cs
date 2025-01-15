using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public readonly struct AccountTransaction(Guid account, double amount)
    {
        public Guid Account { get; } = account;
        public double Amount { get; } = amount;
        public DateTime Created { get; } = DateTime.Now;

    }
}
