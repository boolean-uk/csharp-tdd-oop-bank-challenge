using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public struct OverdraftRequest
    {
        public OverdraftRequest(Guid account, float amount)
        {
            Account = account;
            Amount = amount;
        }

        public Guid Account { get; set; }
        public float Amount { get; set; }
    }
}
