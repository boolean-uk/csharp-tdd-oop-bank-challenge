namespace Boolean.CSharp.Main
{
    public class User
    {
        public Account CreateCurrent(BranchCode branchCode)
        {
            return new CurrentAccount(branchCode);
        }

        public Account CreateSavings(BranchCode branchCode)
        {
            return new SavingsAccount(branchCode);
        }
    }
}
