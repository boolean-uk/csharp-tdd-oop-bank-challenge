// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;

public class Bank : IOverdraftOwner
{
    private static int idCounter = 0; 
    // Note: _accountsPerUser and _accounts points to the same data. added for convinience
    private Dictionary<string, Dictionary<int,Account>> _accountsPerUser = new();
    private Dictionary<int,Account> _accounts = new();
    private Dictionary<int, Action<float>> overdraftConfigs = new();
    private Dictionary<int,float> _requestedOverdrafts = new();
    public Bank()
    {
    }
    private static int getUniqueId()
    {
        return ++idCounter; 
    }

    public int AddAccount<T>(string userName, string accountName, Branch? requestedBranch = null)
        where T : Account, new()
    {
        if (!_accountsPerUser.ContainsKey(userName)) 
            _accountsPerUser[userName] = new Dictionary<int, Account>();

        int uniqueId = getUniqueId();

        // unless specified, branch will always be Stockholm... 
        requestedBranch = requestedBranch ?? Branch.Stockholm;

        T account = Account.Create<T>(this, uniqueId, requestedBranch.Value, userName, accountName);

        _accountsPerUser[userName][uniqueId] = account;
        _accounts[uniqueId] = account;

         return uniqueId;
    }
    private static T? warnAndReturnVal<T>(string msg, T? val)
    {
        warnAndReturnVal(msg);
        return val;
    }
    private static void warnAndReturnVal(string msg)
    {
        Console.WriteLine(msg);
    }
    public bool deposit(int accountId, float sumToDeposit )
    {
        if (!_accounts.ContainsKey(accountId))
            return warnAndReturnVal($"Provided accountId [{accountId}] does not exist", false);         

        _accounts[accountId].deposit(sumToDeposit);

        return true; 
    }
    public float withdraw(int accountId, float sumToWithdraw )
    {
        if (!_accounts.ContainsKey(accountId))
            return warnAndReturnVal($"Provided accountId [{accountId}] does not exist", 0.0f);

        if (_accounts[accountId].withdraw(sumToWithdraw) is float val)
            return val;
        
        return warnAndReturnVal($"Provided accountId [{accountId}] has too little in balance, no money for you", 0.0f);
    }
    public float? getBalance(int accountId)
    {
        if (!_accounts.ContainsKey(accountId))
            return warnAndReturnVal<int?>($"Provided accountId [{accountId}] has too little in balance, no money for you", null);

        return _accounts[accountId].GetBalance; 
    }
    public string requestAccountStatement(int accountId)
    {
        if (!_accounts.ContainsKey(accountId))
            return warnAndReturnVal($"Provided accountId [{accountId}] does not exist, no statement for you", null);

        var accountStatement = _accounts[accountId].getAccountStatement();

        return accountStatement;


    }
    public void requestOverdraft(int accountId, float amount)
    {
        if (!_accounts.ContainsKey(accountId))
            return;
        if(_accounts[accountId] is not IOverdraftable)
        {
            warnAndReturnVal($"Provided accountId [{accountId}], is not a overdraftable account");
            return; 
        }

        if (!_requestedOverdrafts.ContainsKey(accountId))
            _requestedOverdrafts.Add(accountId, 0);
                
        _requestedOverdrafts[accountId] = amount;
    }
    public void handleOverdraftRequests(int accountId, bool approve)
    {
        if (!_requestedOverdrafts.ContainsKey(accountId))
            return;

        if (approve && overdraftConfigs.ContainsKey(accountId) )
            overdraftConfigs[accountId].Invoke(_requestedOverdrafts[accountId]);
        
        _requestedOverdrafts.Remove(accountId);
    }

    public void setConfigFunc(Overdraft overdraft, Action<float> configOverdraft, Account acc)
    {
        if (overdraftConfigs.ContainsKey(acc.ID))
        {
            warnAndReturnVal($"OverdraftConfig already exists for {acc.ID}");
            return;
        }

        overdraftConfigs[acc.ID] = configOverdraft;

    }
}
