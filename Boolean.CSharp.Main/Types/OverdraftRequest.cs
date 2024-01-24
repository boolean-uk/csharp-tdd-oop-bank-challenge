using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.AccountTypes
{
    public class OverdraftRequest
    {
        public IUser User { get; set; }
        public IAccount Accountname { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int Overdraft { get; set; }
        public int Balance { get; set; }

        public OverdraftRequest(IUser User, IAccount Accountname, DateTime Date, int Amount, int Overdraft, int Balance)
        {
            this.User = User;
            this.Accountname = Accountname;
            this.Date = Date;
            this.Amount = Amount;
            this.Overdraft = Overdraft;
            this.Balance = Balance;
        }
    }
}
