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

        public void CreateAccount(string name, string password)
        {
            _AccountList.Add(new User(name, password));
        }

        public List<IAccount> AccountList { get { return _AccountList; } set { _AccountList = value; } }
    }
}
