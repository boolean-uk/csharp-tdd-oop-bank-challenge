using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankAccount
{
    public interface IBankAccount
    {
        string AccountName { get; set; }
        AccountType AccountType { get; }
        List<Transaction> TransactionHistory { get; }
    }
}
