using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Class;
using Boolean.CSharp.Main.Enums;


namespace Boolean.CSharp.Main
{
  
    public class Core
    {
        private Account _currentAccount;
        public Core()
        {
            _currentAccount = new CurrentAccount(Role.Customer);
           

            _currentAccount.Deposit(1000, new DateTime(2012, 1, 10));
            _currentAccount.Deposit(2000, new DateTime(2012, 1, 13));
            _currentAccount.Withdraw(500, new DateTime(2012, 1, 14));
        }

        public void PrintAccountStatements()
        {
            Console.WriteLine(_currentAccount.ToString());
        }

    }
}
