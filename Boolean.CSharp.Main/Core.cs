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
        private List<IUser> _userList = new List<IUser>();

        #region CreateAccount()
        public void CreateUser(string name, string password)
        {
            createUser(name, password);
        }
        private void createUser(string name, string password)
        {
            _userList.Add(new User(name, password));
        }
        #endregion

        #region SavingsAccount()
        #endregion

        public List<IUser> UserList { get { return _userList; } set { _userList = value; } }
    }
}
