using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.User
{
    public class SavingsAccount () : IAccount
    {
        private string owner;
        private int balance;

        public string Owner { get { return owner; } set { owner = value; } }
        public int Balance { get { return balance; } set { balance = value; } }
    }
}
