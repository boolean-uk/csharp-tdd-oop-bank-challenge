using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Core
    {
        private List<IAccount> _AccountList = new List<IAccount>();

        #region CreateAccount()
        public void CreateAccount(string name, string password, bool savingsaccount)
        {
            createAccount(name, password, savingsaccount);
        }
        private void createAccount(string name, string password, bool savingsaccount)
        {
            _AccountList.Add(new User(name, password, savingsaccount));
        }
        #endregion

        #region SavingsAccount()
        public void SavingsAccount(IAccount user)
        {
            savingsAccount(user);
        }
        private void savingsAccount(IAccount user)
        {
            user.SavingsAccount = true;
        }
        #endregion

        public List<IAccount> AccountList { get { return _AccountList; } set { _AccountList = value; } }
    }
}
