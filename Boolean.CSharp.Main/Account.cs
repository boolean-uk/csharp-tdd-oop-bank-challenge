using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        private string name;
        private List<Transaction> transactions;
        private int balance;
        public Account(string name) 
        {
            this.name = name;
            transactions = new List<Transaction>();
        
        }
    }
}
