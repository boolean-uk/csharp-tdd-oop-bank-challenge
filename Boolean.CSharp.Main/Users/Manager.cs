using Boolean.CSharp.Main.CoreFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Manager : User
    {
        public Manager(double startingMoney)
        {
            Money = startingMoney;
        }

        public List<Overdraft> GetOverdraftRequests(Bank bank)
        {
            return bank.GetOverdraftRequests();
        }
    }
}
