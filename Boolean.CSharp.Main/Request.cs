using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Request
    {
        public string ssn = "";
        public string type { get; set; } = "";
        public decimal amount { get; set; } = 0;
        public string accountID;
        public Request(string Type, decimal Amount,string Ssn,string AccountID) 
        {
            type = Type;
            amount = Amount;
            ssn = Ssn;
            accountID = AccountID;

        }
    }
}
