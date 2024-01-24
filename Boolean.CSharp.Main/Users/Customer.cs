using Boolean.CSharp.Main.CoreFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Customer : User
    {
        public Customer(double startingMoney)
        {
            Money = startingMoney;
        }
    }
}
