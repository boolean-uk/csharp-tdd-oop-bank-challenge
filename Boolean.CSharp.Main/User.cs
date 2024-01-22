using Boolean.CSharp.Main.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class User
    {
        private int _id;
        private Saving? _savingAccount = null;
        private Current? _currentAccount = null;
        
        public User(int id) {

            _id = id;
        
        
        }
        public void CreateSavingAccount() {
            _savingAccount = new Saving();
        }
        public void CreateCurrentAccount()
        {
            _currentAccount = new Current();
        }

        public Account SavingAccount { get => _savingAccount; }
        public Account CurrentAccount { get => _currentAccount; }
    }
}
