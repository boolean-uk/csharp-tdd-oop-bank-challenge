
namespace Boolean.CSharp.Main.Bank.AccountTypes
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(string accountType) 
        { 
            AccountType = accountType;
        }

        public bool MakeDeposit(decimal depositAmount)
        {
            throw new NotImplementedException();
        }
    }
}
