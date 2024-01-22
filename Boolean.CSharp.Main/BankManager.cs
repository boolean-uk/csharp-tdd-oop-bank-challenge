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

        public BankManager()
        {
        }

        public void CreateCurrentAccount(string accountName)
        {
            Console.WriteLine("Input name of current account");
            CurrentAccount newCurrentAccount = new CurrentAccount(accountName);
            if (!Accounts.Contains(newCurrentAccount)){
                Accounts.Add(newCurrentAccount);
                Console.WriteLine($"{accountName} has been added to accounts");
            } else
            {
                Console.WriteLine($"{accountName} already exists");
            }
                
        }

        public void CreateSavingsAccount(string accountName)
        {
            Console.WriteLine("Input name of savings account");
            SavingsAccount newSavingsAccount = new SavingsAccount(accountName);
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
