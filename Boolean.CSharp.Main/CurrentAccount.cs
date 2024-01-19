namespace Boolean.CSharp.Main
{
    public class CurrentAccount(Customer customer) : Account(customer)
    {
        public override AccountTypes GetAccountType()
        {
            return AccountTypes.Current;
        }
    }
}