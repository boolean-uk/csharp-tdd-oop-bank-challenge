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

        bool Create(string type,string name);
        bool deposit(decimal amount,IAccount account);
        bool withdraw(decimal amount,IAccount account);
        decimal balance(IAccount account);

        Request requestOverdraft(IAccount account, string justficiation, decimal amount);
        void updateOverdraft(IAccount account,bool status, decimal amount);


    }
}
