using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        string Type { get; set; }

        public List<Transaction> OverdraftRequests { get; }
        public void SortTransactionList(List<Transaction> list) { }
    }
}
