using Boolean.CSharp.Main.Abstract;
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
        public List<AccountAbstract> Accounts { get; set; }
        public User(string username) {
            this.Name = username;
            this.Accounts = new List<AccountAbstract>();
        }

        public string CreateSavingsAccount(string name)
        {
            if (Accounts.OfType<SavingAccount>().Any())
            {
                return "Account already exists";
            }

            AccountAbstract savingAccount = new SavingAccount(name);
            Accounts.Add(savingAccount);
            return "Successfully created account";
        }

        public string CreateCurrentAccount(string name)
        {
            if (Accounts.OfType<CurrentAccount>().Any())
            {
                return "Account already exists";
            }

            AccountAbstract currentAccount = new CurrentAccount(name);
            Accounts.Add(currentAccount);
            return "Successfully created account";
        }

        public CurrentAccount? GetCurrentAccount()
        {
            return (CurrentAccount?)Accounts.FirstOrDefault(a => a.GetType() == typeof(CurrentAccount));
        }
        public SavingAccount? GetSavingsAccount()
        {
            return (SavingAccount?)Accounts.FirstOrDefault(a => a.GetType() == typeof(SavingAccount));
        }
    }
}
