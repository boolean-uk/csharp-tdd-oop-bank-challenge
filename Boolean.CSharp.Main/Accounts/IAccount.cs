namespace Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {
        AccountTypes GetAccountType();
        decimal GetBalance();
        Customer GetAccountOwner();
        bool Deposit(decimal amount);
        bool Withdraw(decimal amount);
        void CreateTransaction(decimal credit, decimal debit);
        List<Transaction> GenerateBankStatement();
        void PrintBankStatement();
        string GetStringBankStatement();
        List<Overdraft> GetOverdraftRequests();
        void HandleOverdraft(Overdraft overdraft, bool approve);
        void SendTransaction(Transaction t);
        void SendBankStatement();

    }
}
