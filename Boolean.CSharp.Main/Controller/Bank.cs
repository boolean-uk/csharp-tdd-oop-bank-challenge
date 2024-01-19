namespace Boolean.CSharp.Main;

public class Bank {
    private Dictionary<Guid, IAccount> _accounts;
    private List<Transaction> _overdraft;

    public Dictionary<Guid, IAccount> Accounts => _accounts;
    public List<Transaction> Overdrafts => _overdraft;
    public Bank() {
        this._accounts = new Dictionary<Guid, IAccount>();
        this._overdraft = new List<Transaction>();
    }

    public string AddAccount(IAccount account) {
        if(_accounts.Values.Contains(account)) {
            return "Account already in bank";
        }
        _accounts.Add(account.Id, account);
        return "Account Added!";
    }

    public string RemoveAccount(IAccount account) {
        if(!_accounts.Values.Contains(account)) {
            return "Account does not exist!";
        }
        _accounts.Remove(account.Id);
        return "Account Removed!";
    }

    public Transaction RequestOverdraft(IAccount account, int amount) {
        if(!_accounts.Values.Contains(account)) {
            return new Transaction(account.Id, 001, 001, TransactionType.CREDIT, new Signature());
        }
        Transaction transaction = new Transaction(account.Id, amount, account.GetBalance(), TransactionType.CREDIT ,account.Signature);
        _overdraft.Add(transaction);
        return transaction;
    }

    public string ApproveOverdraft(Signature signature, Transaction transaction) {
        if (!signature.IsManager) {
            return "Not Bank Manager";
        }

        return ProcessOverdraft(transaction, true);
    }

    public string DeclineOverdraft(Signature signature, Transaction transaction) {
        if (!signature.IsManager) {
            return "Not Bank Manager";
        }

        return ProcessOverdraft(transaction, false);
    }

    private string ProcessOverdraft(Transaction transaction, bool approve) {
        if (!_overdraft.Contains(transaction)) {
            return "Not in List of accounts";
        }

        if (_accounts.ContainsKey(transaction.AccountID) && _accounts[transaction.AccountID].Id == transaction.AccountID) {
            if (approve) {
                _accounts[transaction.AccountID].Deposit(transaction);
                _overdraft.Remove(transaction);
                return "Approved!";
            } else {
                _overdraft.Remove(transaction);
                return "Declined!";
            }
        }
        return "Unknown";
    }
}