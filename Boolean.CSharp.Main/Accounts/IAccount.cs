using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Boolean.CSharp.Main.Transactions;
namespace Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {
         string AccountNumber { get; }

        //decimal Balance { get; }

         decimal getBalance();

         AccountType Type { get; }

         List<Transaction> Transaction { get; set; }

         bool deposit(decimal amount);

         bool withdraw(decimal amount);

         void GenerateStatement();


    }
}
