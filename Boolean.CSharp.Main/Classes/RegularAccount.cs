using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Boolean.CSharp.Main.Classes
{
    public class RegularAccount : IAccount
    {
        public bool Create(string type, string name)
        {
            if (type == "Regular")
            {
                RegularAccount account = new RegularAccount(name,new List<Transaction>());
                return true;
            }
            return false;
        }


        public bool deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public bool withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }

        public decimal balance()
        {
            throw new NotImplementedException();
        }


        public string nameOfHolder { get; set; }

        private List<Transaction> _transactionList = new List<Transaction>();


        public RegularAccount() { }
        public RegularAccount(string nameOfHolder, List<Transaction> transactionList)
        {
            this.nameOfHolder = nameOfHolder;
            _transactionList = transactionList;
        }

        public List<Transaction> transactionList { get { return _transactionList; } }

    }
}
