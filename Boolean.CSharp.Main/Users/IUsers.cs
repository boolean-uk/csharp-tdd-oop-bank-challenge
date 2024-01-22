using Boolean.CSharp.Main.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public interface IUsers
    {

        string Name { get; set; }
        int Id { get; set; }
        bool IsActive { get; }

        public void makeAccount(AccountType accType);

    }
}
