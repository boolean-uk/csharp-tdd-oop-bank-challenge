using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;

namespace Boolean.CSharp.Main
{
    public static class BankData
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Account> Accounts { get; set; } = new List<Account>();
        public static List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
