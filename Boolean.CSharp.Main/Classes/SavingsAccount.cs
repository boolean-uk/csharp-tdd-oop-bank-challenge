using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class SavingsAccount : IAccount
    {
        public bool Create(string type,string name)
        {
            throw new NotImplementedException();
        }

        public bool deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public bool withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> transactionList = new List<Transaction>();

        public string nameOfHolder {  get; set; }

        public bool overdrafted {  get; set; }

        decimal rent {  get; set; }

        public decimal overdraftedAmount { get; set; }
    }
}
