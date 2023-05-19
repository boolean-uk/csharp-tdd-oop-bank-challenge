using Boolean.CSharp.Main.CustomerAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Core
    {
        private string _bankName;

        public Core(string name)
        {
            bankName = name;
        }

        public bool makeADeposit(Users.User user, Account account, int amount)
        {
            if (user is Users.Customer)
            {
                if (account is CurrentAccount)
                {
                    ((Users.Customer)user).account1.deposit(amount);
                    return true;
                }
                if (account is SavingsAccount)
                {
                    ((Users.Customer)user).account2.deposit(amount);
                    return true;
                }
            }
            return false;
        }

        public bool makeAWithdraw(Users.User user, Account account, int amount)
        {
            if (user is Users.Customer)
            {
                if (account is CurrentAccount)
                {
                    ((Users.Customer)user).account1.withdraw(amount);
                    return true;
                }
                if (account is SavingsAccount)
                {
                    ((Users.Customer)user).account2.withdraw(amount);
                    return true;
                }
            }
            return false;
        }

        public List<Transaction.Transaction> printBankStatement(Users.User user, Account account)
        {
            List<Transaction.Transaction> list = new List<Transaction.Transaction>();
            if (user is Users.Customer)
            {
                if (account is CurrentAccount)
                {
                    list = ((Users.Customer)user).account1.printBankStatement();
                }
                if (account is SavingsAccount)
                {
                    list = ((Users.Customer)user).account2.printBankStatement();
                }
            }
            return list;
        }



        public string bankName { get { return _bankName; } set { _bankName = value; } }
    }
}
