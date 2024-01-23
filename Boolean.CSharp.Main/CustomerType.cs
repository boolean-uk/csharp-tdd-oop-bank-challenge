using Boolean.CSharp.Main.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CustomerType
    {
        private int _id;
        private Saving _savingAccount = new Saving();
        private Current _currentAccount = new Current();
        private int _branch = 0;
        private bool isAdmin = false;

      
        public void CreateSavingAccount()
        {
            _savingAccount = new Saving();
        }
        public void CreateCurrentAccount()
        {
            _currentAccount = new Current();
        }
        public int setBranch(int branchNum)
        {
            _branch = branchNum;
            return branchNum;
        }
        public void setId(int id)
        {
            _id= id;
        }

        protected void setAdmin(bool adminpriviliges)
        {
            isAdmin = adminpriviliges;
        }

        public Saving SavingAccount { get => _savingAccount; }
        public Current CurrentAccount { get => _currentAccount; }
        public int Id { get => _id; }
        public bool IsAdmin { get {  return isAdmin; } }
        public int Branch { get => _branch; set => _branch = value; }
    }
}
