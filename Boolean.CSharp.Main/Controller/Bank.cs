namespace Boolean.CSharp.Main;

public class Bank {
    private List<IAccount> _accounts;
    private List<Transaction> _overdraft;

    public List<IAccount> Accounts => _accounts;
    public List<Transaction> Overdrafts => _overdraft;
    public Bank() {
        this._accounts = new List<IAccount>();
        this._overdraft = new List<Transaction>();
    }

    public string AddAccount(IAccount account) {
        return "";
    }

    public string RemoveAccount(IAccount account) {
        return "";
    }

    public Transaction RequestOverdraft(IAccount account, int amount) {
        return new Transaction(1000, account.GetBalance(), account.Signature);
    }

    public string ApproveOverdraft(Signature signature, Transaction transaction) {
        return "";
    }

    public string DeclineOverdraft(Signature signature, Transaction transaction) {
        return "";
    }

}