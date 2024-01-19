# TDD

## User Stories

As a customer,
So I can safely "store" "use" my "money",
I want to !create! a "current account".

As a customer,
So I can "save" for a rainy day,
I want to !create! a "savings account".

As a customer,
So I can keep a record of my finances,
I want to !generate! "bank statements" with "transaction dates", "amounts", and "balance at the time of transaction".

As a customer,
So I can use my account,
I want to !deposit! and !withdraw! "funds".

## Domain Model

### Interface IAccount

    private float _balance {get; }
    private List<Transaction> _transactions {get; }
    private BankStatementBuilder _bankStatementBuilder;

    bool Deposit(float ammount)
    bool Withdraw(float ammount)
    string GetBankStatement()

### AccountBase : IAccount

    private float _balance;
    private List<Transaction> _transactions = new List<Transaction>();
    private string _accountName;

    public float Balance => _balance;
    public List<Transaction> Transactions => _transactions;
    public string AccountName => _accountName;
    
    constructor AccountBase(string accountname, BankStatementBuilder bankStatementBuilder)

    public bool Deposit(float amount)
        _balance += amount;
        return true;

    public bool Withdraw(float amount)
        if (_balance >= amount)
        {
            _balance -= amount;
            return true;
        }
        return false;

    public string GetBankStatement()
        return string from ;

### Class CurrentAccount : AccountBase

    if we want currentACcount to do something other than base account we can add it here

### Class SavingsAccount : AccountBase

    if we want savingsAccount to do something other than current account we can add it here

### Class Transaction

    private DateTime _time {get; }
    private string _typeOfTransaction {get; }
    private float _amount {get; }
    private float _balance {get; }
    public enum TransactionType
    {
        Credit,
        Debit
    }
    
    constructor(DateTime time, string typeOfTransaction, float amount, float balance)

### Class Bank

    public CurrentAccount createCurrentAccount(Customer customer)
        CurrentAccount newaccount = new CurrentAccount(); 
        customer.AddAccount(newaccount)
        return newaccount

    public SavingsAccount createSavingsAccount(Customer customer)
        CurrentAccount newaccount = new CurrentAccount(); 
        customer.AddAccount(newaccount)
        return newaccount

### Class Customer

    private List<IAccount> _accounts {get; };

    public void AddAccount(IAccount account)
        _accounts.Add(account)

### Class BankStatementBuilder

    private List<IAccount> _accounts {get; };

    public void AddAccount(IAccount account)
        _accounts.Add(account)
