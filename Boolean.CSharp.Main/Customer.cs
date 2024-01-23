namespace Boolean.CSharp.Main;

public class Customer
{
    private string _name;
    private string _customerNr;
    private string _bankNr;
    private Manager _manager;
    private IMessage _messenger;

    private List<BankAccount> _accounts;
    public Customer(string name, string customerNr, string bankNr, Manager manager, IMessage messenger)
    {
        _name = name;
        _customerNr = customerNr;
        _bankNr = bankNr;
        _accounts = new List<BankAccount>();
        _manager = manager;
        _messenger = messenger;
    }

    public string Name { get { return _name; } }
    public string CustomerNr { get { return _customerNr; } }

    public bool createCurrentAccount(string controllNr)
    {
        if (controllNr.Trim().Length == 1)
        {
            string accountNumber = _bankNr + _customerNr + controllNr.Trim();
            if (!_accounts.Exists(x => x.AccountNumber == accountNumber))
            {
                _accounts.Add(new CurrentAccount(accountNumber));
                Console.WriteLine("CurrentAccount created");
                return true;
            }
            Console.WriteLine("Account number already exists");
            return false;
        }
        Console.WriteLine("controll number is invalid (length has to be 1)");
        return false;
    }

    public bool createSavingsAccount(string controllNr)
    {
        if (controllNr.Trim().Length == 1)
        {
            string accountNumber = _bankNr + _customerNr + controllNr.Trim();
            if (!_accounts.Exists(x => x.AccountNumber == accountNumber))
            {
                _accounts.Add(new SavingsAccount(accountNumber));
                Console.WriteLine("CurrentAccount created");
                return true;
            }
            Console.WriteLine("Account number already exists");
            return false;
        }
        Console.WriteLine("controll number is invalid (length has to be 1)");
        return false;
    }

    public BankAccount? getAccountByNumber(string accountNumber)
    {
        return _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
    }

    public void createOverdraftRequest(int id, string accountNr, double amount)
    {
        if (_manager.getOverdraftRequestById(id) == null)
        {
            BankAccount bankAccount = getAccountByNumber(accountNr);
            OverdraftRequest request = new OverdraftRequest(id, bankAccount, amount);
            _manager.addOverdraftRequest(request);
        }
    }

    public void sendBankStatementToMessage(string accountNumber)
    {
        BankAccount account = getAccountByNumber(accountNumber);

        _messenger.sendMessage(account.generateBankStatement());
    }
}
