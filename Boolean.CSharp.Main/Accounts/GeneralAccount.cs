using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class GeneralAccount : PersonalAccount
    {
        public GeneralAccount(Customer user) : base(user)
        {
        }
    }
}
