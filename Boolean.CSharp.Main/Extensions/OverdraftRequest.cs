using Boolean.CSharp.Main.Acounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Extensions
{
    public class OverdraftRequest
    {

        public decimal Amount {  get; set; }

        public OverdraftStatus Status { get; set; } = OverdraftStatus.DECLINED;

        public Account Account { get; set; }

        public OverdraftRequest(decimal amount, Account account)
        {
            Amount = amount;
            Account = account;
        }

        public void Accept() { Status = OverdraftStatus.ACCEPTED; }
    }
}
