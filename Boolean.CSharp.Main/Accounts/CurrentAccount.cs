using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount : IAccount
    {
        public int ID { get; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();

        public double Balance { get; set; } = 0;

        //public string Branch { get; set; }

        public CurrentAccount(int ID, string type, string owner)
        {
            this.ID = ID;
            Type = type;
            Owner = owner;
        }
    }
}
