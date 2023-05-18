using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingApp.Boolean.CSharp.Main.Interfaces
{
    public interface IAccount
    {
        float Balance { get; set; }
        List <Transaction> Transactions { get; set; } 
    }
}
