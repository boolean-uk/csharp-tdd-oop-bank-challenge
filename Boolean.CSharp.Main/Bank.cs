namespace Boolean.CSharp.Main
{
    public class Bank
    {

        public void RequestOverdraft(bool customerSeemsResponsible, CurrentAccount account)
        {
            if (customerSeemsResponsible)
            {
                account.Overdraft = true;
            }
        }
    }
}