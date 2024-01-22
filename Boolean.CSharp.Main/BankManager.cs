using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankManager
    {
        AccountList accountList = new AccountList();


        public void CreateCurrentAccount()
        {
            Console.WriteLine("Input name of current account");
            string accountName = Console.ReadLine();
            CurrentAccount newCurrentAccount = new CurrentAccount(accountName);
            if (!accountList.Accounts.Contains(newCurrentAccount)){
                accountList.Accounts.Add(newCurrentAccount);
                Console.WriteLine($"{accountName} has been added to accounts");
            } else
            {
                Console.WriteLine($"{accountName} already exists");
            }
                
        }

        public void CreateSavingsAccount()
        {
            Console.WriteLine("Input name of savings account");
            string accountName = Console.ReadLine();
            SavingsAccount newSavingsAccount = new SavingsAccount(accountName);
            if (!accountList.Accounts.Contains(newSavingsAccount))
            {
                accountList.Accounts.Add(newSavingsAccount);
                Console.WriteLine($"{accountName} has been added to accounts");
            } else
            {
                Console.WriteLine($"{accountName} already exists");
            }
            
        }

        
    }
}
