using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private int _id;
        private string _type;
        private decimal _availableAmount;
        private Bank _bank = new Bank();

        public Account()
        {
            _id = _bank.GenerateId();
            _type = "current";
            _availableAmount = 0;
        }
        public void Deposit(decimal amount)
        {
            Console.WriteLine("deposit {0}",amount);
        }
        public void Withdraw(decimal amount)
        {
            Console.WriteLine("deposit {0}",amount);
        }

        protected void SetType(string type) { _type = type; }

        public List<string> GenerateBankstatement()
        {
            throw new NotImplementedException();
        }

        public string Type { get => _type; }
        public decimal Balance { get => _availableAmount; set => _availableAmount=value; }
        public int Id { get =>  _id; set => _id = value;}
    }
}
