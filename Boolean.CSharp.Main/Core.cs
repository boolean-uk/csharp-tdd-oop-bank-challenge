using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Core
    {
        public List<IUser> userList = new List<IUser>();

        public void creatBankAcc(IUser user, AccountType type)
        {
            if (type == AccountType.Current)
            {
                user.AccountList.Add(new CurrentAcc(type));
            }
        }

        public void CreateUserAcc(string name, string password, List<IAccount> AccountList)
        {
            createUserAcc(name,password,AccountList);
        }

        private void createUserAcc(string name, string password, List<IAccount> accountList)
        {
            userList.Add(new Customer(name, password, accountList));
        }


    }
}
