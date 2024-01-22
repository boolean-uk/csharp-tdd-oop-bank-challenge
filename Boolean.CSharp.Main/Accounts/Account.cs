using Boolean.CSharp.Main.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account : IAccount
    {
        public AccountType _Type; 
        public int _AccId { get; set; }

        public bool _IsAccActive { get; set; } = true;
        public Branches _Branch { get; }

        Random randomID = new Random();

        public Account(Branches branch) {
            _Branch = branch;
            _AccId = randomID.Next(1000);
            
        }



    }
}
