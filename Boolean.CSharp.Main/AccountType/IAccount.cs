using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Test;

namespace Boolean.CSharp.Main.AccountType
{
    public interface IAccount
    {
        List<Transaction> transactions { get; set; }
        Customer customer { get; set; }
        double balance { get; set; }
        double deposit(double amount);
        double withdraw(double amount);
        
    }
}
