namespace Boolean.CSharp.Main.Model
{
    internal interface IAccount
    {

       List<string> GenerateBankStatment();

       string GetAccountName();

       void DepositFunds(double funds);

        void WithdrawFunds(double funds);

        string GetBalance();

        void SetBranch(string branch);

        string GetBranch();
    }
}