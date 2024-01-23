using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Objects;

namespace Boolean.CSharp.Main
{
    public class BankManager
    {
        public List<Account> Accounts {  get; set; } = new List<Account>();


        public void CreateCurrentAccount(string accountName, Branch branch)
        {
            Console.WriteLine("Creating current account");
            CurrentAccount newCurrentAccount = new CurrentAccount(accountName, branch);
            if (!Accounts.Contains(newCurrentAccount)){
                Accounts.Add(newCurrentAccount);
                Console.WriteLine($"{accountName} has been added to accounts");
            } else
            {
                Console.WriteLine($"{accountName} already exists");
            }
                
        }

        public void CreateSavingsAccount(string accountName, Branch branch)
        {
            Console.WriteLine("Creating savings account");
            SavingsAccount newSavingsAccount = new SavingsAccount(accountName, branch);
            if (!Accounts.Contains(newSavingsAccount))
            {
                Accounts.Add(newSavingsAccount);
                Console.WriteLine($"{accountName} has been added to accounts");
            } else
            {
                Console.WriteLine($"{accountName} already exists");
            }
            
        }

        
    }
}
