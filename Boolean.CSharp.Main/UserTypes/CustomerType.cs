using Boolean.CSharp.Main.AccountTypes;
using NUnit.Framework;
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
        private decimal _limit = 30000m;

      
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

        public string ManageOverdraftRequests(IAccount account)
        {
            if(isAdmin) {

                List<Transaction> lines = new List<Transaction>();
            foreach (Transaction line in account.OverdraftRequests)
            {
                if ((line.TransactionAmount < _limit) && (line.Balance + line.TransactionAmount> 0))
                {
                        line.TransactionStatus = Status.approved.ToString();
                        line.Date = DateTime.Now.Date;
                        lines.Add(line);
                    }
                    else { 
                        line.TransactionStatus = Status.rejected.ToString();
                        lines.Add(line);
                    }
            }
                account.SortTransactionList(lines);
                return "Overdraft Requests approved if Balance>0 and requested amount< 30 000";   
            }
            else { return "Administrator not approved"; }
        }

        private void SetOverdraftLimit(decimal newlimit)
        {
            if (isAdmin)
            {
                _limit = newlimit;
            }
        }

        public Saving SavingAccount { get => _savingAccount; }
        public Current CurrentAccount { get => _currentAccount; }
        public int Id { get => _id; }
        public bool IsAdmin { get {  return isAdmin; } }
        public int Branch { get => _branch; set => _branch = value; }

        public decimal Limit { get => _limit; set => SetOverdraftLimit(value); }
    }
}
