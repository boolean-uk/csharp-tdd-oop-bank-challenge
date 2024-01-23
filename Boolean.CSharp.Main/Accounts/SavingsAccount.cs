namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount(Customer customer, AccountBranches ab, ISmsService service) : Account(customer, ab, service)
    {
        public override AccountTypes GetAccountType()
        {
            return AccountTypes.Savings;
        }
    }
}