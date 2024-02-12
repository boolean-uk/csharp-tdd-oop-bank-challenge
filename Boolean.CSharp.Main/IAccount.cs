using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public Account Type { get; set; }
        public Branch Branch { get; set; }
        public Overdraft Overdraft { get; set; }

    }

}
