namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount(Customer customer, AccountBranches ab, ISmsService smsService) : Account(customer, ab, smsService)
    {
        public override AccountTypes GetAccountType()
        {
            return AccountTypes.Current;
        }
    }
}