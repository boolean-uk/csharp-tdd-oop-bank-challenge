using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class Request
    {
        public Request(string justficiation, decimal amount, IAccount account)
        {
            this.justficiation = justficiation;
            this.amount = amount;
            this.account = account;
        }

        public Request() { }

        public string justficiation {  get; set; }

        public decimal amount { get; set; }

        public IAccount account { get; set; }
    }
}
