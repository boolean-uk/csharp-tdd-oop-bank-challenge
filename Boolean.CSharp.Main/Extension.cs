
using Boolean.CSharp.Main.CustomerAccounts;
using Boolean.CSharp.Main.EngineerAccount;
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
        public Extension(string name)
        {
            BankName = name;
        }
        public decimal makeADeposit(Users.User user, EngineerAccount.EngineerAccount account, int amount)
        {
            decimal total = 0;
            if (user is Users.Engineer)
            {
                if (account is EngineerCurrentAccount)
                {
                    total = ((Users.Engineer)user).account1.deposit(amount);
                }
                if (account is EngineerSavingsAccount)
                {
                    total = ((Users.Engineer)user).account2.deposit(amount);
                }
            }
            return total;
        }
        public decimal makeAWithdraw(Users.User user, EngineerAccount.EngineerAccount account, int amount)
        {
            decimal total = 0;
            if (user is Users.Engineer)
            {
                if (account is EngineerCurrentAccount)
                {
                    total = ((Users.Engineer)user).account1.withdraw(amount);
                }
                if (account is EngineerSavingsAccount)
                {
                    total = ((Users.Engineer)user).account2.withdraw(amount);
                }
            }
            return total;
        }

        public List<Transaction.Transaction> printBankStatement(Users.User user, EngineerAccount.EngineerAccount account)
        {
            List<Transaction.Transaction> list = new List<Transaction.Transaction>();
            if (user is Users.Engineer)
            {
                if (account is EngineerCurrentAccount)
                {
                    list = ((Users.Engineer)user).account1.printBankStatement();
                }
                if (account is SavingsAccount)
                {
                    list = ((Users.Engineer)user).account2.printBankStatement();
                }
            }
            return list;
        }

        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }
    }
}
