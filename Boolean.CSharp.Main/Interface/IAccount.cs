using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Boolean.CSharp.Main.Interface
{
    public interface IAccount
    {
        string AccountNumber { get; }

        public AccountType Type { get; }
   
        void deposit(decimal amount);

        void withdraw(decimal amount);


    }
}
