using Boolean.CSharp.Main.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class SavingAccount : IAccount
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public SavingAccount(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
        public SavingAccount(string name)
        {
            this.Name = name;
            this.Balance = 0;
        }
    }
}
