using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interface
{
    public interface IAccount
    {
        Guid Id { get; set; }
        string accountType { get; set; }
        decimal accountBalance { get; set; }
        string name { get; set; }

        List<ITransaction> transactions { get; set; }

        public List<ITransaction>GetTransactions() { return transactions; }
        public void AddTransaction(ITransaction transaction) { transactions.Add(transaction); }    
        
    }
}
