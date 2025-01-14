using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main
{
    public class Savings : IAccount
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string accountType { get; set; } = "Savings";
        public decimal accountBalance { get; set; } = 0;
        public string name { get; set; }
        public List<ITransaction> transactions { get; set; }
        
        public Savings(string _name)
        {
            name = _name;
            transactions = new List<ITransaction>();
        }

        public List<ITransaction> GetTransactions()
        {
            return transactions;
        }
    }
}
