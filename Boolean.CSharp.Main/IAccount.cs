using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        public string account_id { get; set; }
        public int balance { get; set; }
        public Account Account_type { get; set; }
        public Branch Branch { get; set; }
        public Overdraft Overdraft { get; set; }



        /*        public void Create_Account(string account_id, int balance, string account_type)
                {
                    this.account_id = account_id;
                    this.balance = balance;
                    if (account_type == "Current")
                    {
                        this.account_type = Account.Current;
                    }else if (account_type == "Savings")
                    {
                        this.account_type = Account.Savings;
                    }
                }*/
    }
}
