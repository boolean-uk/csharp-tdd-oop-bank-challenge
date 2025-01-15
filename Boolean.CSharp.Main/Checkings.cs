using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main
{
    public class Checkings : IAccount
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string accountType { get; set; } = "Checkings";
        public decimal accountBalance { get; set; } = 0;
        public string name { get; set; }
        public string accountHolder {  get; set; }
        public List<ITransaction> transactions { get; set; }
        public string location { get; set; }
       

        public Checkings(string _name, string _location)
        {
            name = _name;
            transactions = new List<ITransaction>();
            location = _location;
        }

        public List<ITransaction> GetTransactions()
        {
            return transactions.OrderByDescending(t => t.transactionDate).ToList();
        }
    }
}
