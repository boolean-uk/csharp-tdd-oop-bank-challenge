using Boolean.CSharp.Main.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.CoreFiles;
using Boolean.CSharp.Main.Users;

namespace Boolean.CSharp.Main.CoreFiles
{
    public abstract class Account
    {
        public User Owner { get; protected set; }
        public Guid ID { get; } = Guid.NewGuid();
        public List<Transaction> transactionHistory = new List<Transaction>();
        private MobilePhone _mobilePhone = new MobilePhone();
        private double _money = 0;

        public Account(User user, MobilePhone mobile = null)
        {
            Owner = user;
        }

        public double GetBalance()
        {
            return transactionHistory.Sum(x => x.Amount);
        }

        public Transaction GetBankStatement() 
        {

            throw new NotImplementedException();
        }

        public bool SetMobile(MobilePhone mobile)
        {
            if (mobile == default(MobilePhone) || mobile == null)
                return false;

            _mobilePhone = mobile;
            return true;
        }

        public bool Deposit(double moneyAmount)
        {
            if(Owner.Money < moneyAmount)
                return false;

            _money += moneyAmount;
            Owner.Money -= moneyAmount;
            return true;
        }
        public bool Withdrawl(double moneyAmount)
        {
            if (_money < moneyAmount)
                return false;

            Owner.Money += moneyAmount;
            _money -= moneyAmount;
            return true;
        }
    }
}
