using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IAccount
    {

        bool Create(string type,string name);
        bool deposit(decimal amount);
        bool withdraw(decimal amount);
        decimal balance();


    }
}
