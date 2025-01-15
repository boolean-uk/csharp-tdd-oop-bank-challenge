using Boolean.CSharp.Main.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IAccount
    {

        string AccountHolderName { get; set; }
        bool Create(string type,string name);
        bool deposit(decimal amount,string receiver);
        bool withdraw(decimal amount,string receiver);
        decimal balance(string Receiver);

       


    }
}
