using Boolean.CSharp.Main.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class BankBranch
    {
        public List<User> UserAccounts;
        public List<CurrentAccount> currAccounts;
        string Location { get; set; }
        public BankBranch(string location) 
        {
            UserAccounts = new List<User>();
            this.Location = location;
            this.currAccounts = new List<CurrentAccount>();
        }
        public void AddUser(User user)
        {
            if (user != null)
            {
                user.branch = this;
                this.UserAccounts.Add(user);
            }
        }
        public void RemoveUser(User user)
        {
            if (user != null)
            {
                this.UserAccounts.Remove(user);
            }
        }

        public bool AnswerOverdraftRequest(CurrentAccount account, bool answer)
        {
            if (!currAccounts.Contains(account))
            {
                return false;
            }
            account.SetOverdraft(answer);
            currAccounts.Remove(account);
            return true;
        }

    }
}
