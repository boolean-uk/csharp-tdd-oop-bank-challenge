using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    //using an interface here incase another developer would want to change methods in accountbase they know they have to include atleast deposit, withdraw, getbankstatement and the properties since savings and current need those functionalities and are children of accountbase
    public interface IAccount
    {
        float Balance { get; }
        List<Transaction> Transactions { get; }
        string AccountName {get;}
        bool Deposit(float amount);
        bool Withdraw(float amount);
        string GetBankStatement();
    }
}
