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
        private static int _accountCounter = 0;     //To keep track of how many acc we have created.

        public AccountType _Type;
        public string _AccId { get; set; }

        public bool _IsAccActive { get; set; } = true;
        public Branches _Branch { get; }

        Random randomID = new Random();

        public Account(Branches branch) {
            _Branch = branch;
            
            int accountIdSuffix = System.Threading.Interlocked.Increment(ref _accountCounter);
            //Generates the uniq account ID
            _AccId = $"{_Branch}-{accountIdSuffix:D5}"; //"brach-0000X


        }





    }
}
