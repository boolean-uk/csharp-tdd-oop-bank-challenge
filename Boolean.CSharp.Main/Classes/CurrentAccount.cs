using Boolean.CSharp.Main.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class CurrentAccount : IAccount
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public CurrentAccount(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
        public CurrentAccount(string name)
        {
            this.Name = name;
            this.Balance = 0;
        }
    }
}
