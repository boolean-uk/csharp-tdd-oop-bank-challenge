using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Test
{
    public class BankManager : IBankManager
    {
        public BankManager(string name)
        {
             
        }
        public string ManageOverdraftRequest(AccountCurrent currentAccount, bool approved)
        {
            throw new NotImplementedException();
        }
    }
}