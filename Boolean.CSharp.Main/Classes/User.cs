using Boolean.CSharp.Main.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class User : IUser
    {


        public string Name { get; set; }
        public List<IAccount> Accounts { get; set; }
        public User(string username) {
            this.Name = username;
            this.Accounts = new List<IAccount>();
        }

        public string CreateSavingsAccount(string name)
        {
            if (Accounts.OfType<SavingAccount>().Any())
            {
                return "Account already exists";
            }

            IAccount savingAccount = new SavingAccount(name);
            Accounts.Add(savingAccount);
            return "Successfully created account";
        }

        public string CreateCurrentAccount(string name)
        {
            if (Accounts.OfType<CurrentAccount>().Any())
            {
                return "Account already exists";
            }

            IAccount currentAccount = new CurrentAccount(name);
            Accounts.Add(currentAccount);
            return "Successfully created account";
        }

        public IAccount? GetCurrentAccount()
        {
            return Accounts.FirstOrDefault(a => a.GetType() == typeof(CurrentAccount));
        }
        public IAccount? GetSavingsAccount()
        {
            return Accounts.FirstOrDefault(a => a.GetType() == typeof(SavingAccount));
        }

        public void Deposit(IAccount account, double amount)
        {
            if(amount < 0)
            {
                return;
            }
            account.Balance += amount;
        }
        public void Withdraw(IAccount account, double amount)
        {
            if(amount > account.Balance)
            {
                return;
            }
            account.Balance -= amount;
        }

        public void GenerateReport()
        {
            throw new NotImplementedException();
        }
    }
}
