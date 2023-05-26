using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public class Overdraft
    {
        public int _id { get; set; }
        public decimal _amount { get; set; }
        public string _name { get; set; }
        public AccountType accountType { get; set; }
        public bool _status { get; set; } = false;
    }
}
