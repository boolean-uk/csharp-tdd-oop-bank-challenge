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
        bool SavingsAccount {  get; set; }
        List<Transaction> TransactionHistory { get; set; }
    }
}
