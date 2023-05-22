
using Boolean.CSharp.Main.CustomerAccounts;
using Boolean.CSharp.Main.EngineerAccount;
using Boolean.CSharp.Main.ManagerAccount;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Extension
    {
        private string _bankName;
        public Dictionary<User, int> funds = new Dictionary<User, int>();
        public Extension(string name)
        {
            BankName = name;
        }
        public decimal makeADeposit(User user, EngineerAccount.EngineerAccount account, int amount)
        {
            decimal total = 0;
            if (user is Engineer)
            {
                if (account is EngineerCurrentAccount)
                {
                    total = ((Engineer)user).account1.deposit(amount);
                }
                if (account is EngineerSavingsAccount)
                {
                    total = ((Engineer)user).account2.deposit(amount);
                }
            }
            return total;
        }
        public decimal makeAWithdraw(User user, EngineerAccount.EngineerAccount account, int amount)
        {
            decimal total = 0;
            if (user is Engineer)
            {
                if (account is EngineerCurrentAccount)
                {
                    total = ((Engineer)user).account1.withdraw(amount);
                }
                if (account is EngineerSavingsAccount)
                {
                    total = ((Engineer)user).account2.withdraw(amount);
                }
            }
            return total;
        }

        public List<Transaction.Transaction> printBankStatement(User user, EngineerAccount.EngineerAccount account)
        {
            List<Transaction.Transaction> list = new List<Transaction.Transaction>();
            if (user is Engineer)
            {
                if (account is EngineerCurrentAccount)
                {
                    list = ((Engineer)user).account1.printBankStatement();
                }
                if (account is SavingsAccount)
                {
                    list = ((Engineer)user).account2.printBankStatement();
                }
            }
            return list;
        }

        public bool makeADepositManager(User user, ManagerAccount.ManagerAccount account, int amount)
        {
            if (user is Manager)
            {
                if (account is ManagerCurrentAccount)
                {
                    return ((Manager)user).account1.deposit(amount);
                }
                if (account is ManagerSavingsAccount)
                {
                    return ((Manager)user).account2.deposit(amount);
                }
            }
            return false;
        }

        public bool makeAWithdrawManager(User user, ManagerAccount.ManagerAccount account, int amount)
        {
            if (user is Manager)
            {
                if (account is ManagerCurrentAccount)
                {
                    return ((Manager)user).account1.withdraw(amount);
                }
                if (account is ManagerSavingsAccount)
                {
                    return ((Manager)user).account2.withdraw(amount);
                }
            }
            return false;
        }

        public void addBranchToAccount(Manager user, ManagerAccount.ManagerAccount account, string branch)
        {
            if (user is Manager)
            {
                if (account is ManagerCurrentAccount)
                {
                    ((ManagerCurrentAccount)account).addBranch(branch);
                }
                if (account is ManagerSavingsAccount)
                {
                    ((ManagerSavingsAccount)account).addBranch(branch);
                }
            }

        }

        public void requestFound(User user1, User user2, Account account, int amount)
        {
            if (user1 is Customer)
            {
                funds.Add(user1, amount);
                KeyValuePair<User, int> kvp = new KeyValuePair<User, int>(user1, amount);
                foundManage(user2, account, kvp);
            }
        }
        public void foundManage(User user, Account account, KeyValuePair<User, int> kvp)
        {
            if (user is Manager)
            {
                if (kvp.Value < 500)
                {
                    if (account is CurrentAccount)
                    {
                        Customer c = (Customer)kvp.Key;
                        c.account1.Balance += kvp.Value;
                        funds.Remove(kvp.Key);
                    }
                }
            }
        }

        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }
    }
}
