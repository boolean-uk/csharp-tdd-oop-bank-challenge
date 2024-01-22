Domain model


public class BankUser
    public List<Account> Accounts { get; } = new List<Account>();
        

 Methods
    public bool CreateSavingsAccount() 
        creates a savings account, with balace 0, added to the list of accounts
        returns true if the savings account is created 
    public bool CreateCurrentAccount()
        creates a current account, with balance 0, added to a list of accounts
           returns true if the account was created 

    

public abstract class Account
    public List<Transaction> Transactions { get; } = new List<Transaction>();

Methods
    public virtual bool Deposit(decimal amount)
        deposits money into an account, returns true
    public virtual bool Withdraw(decimal amount)
        withdraws money from an account, returns true, if money was withdrawn
    protected void RecordTransaction(Transaction transaction)
        records the transaction for the bankstatement
    public abstract string GenerateStatement();
    public decimal getBalance();
        returns the decimal Balance






public class CurrentAccount : Account
    public List<Transaction> Transactions { get; } = new List<Transaction>();
    constructor CurrentAccount() {}

Methods:
    public override string GenerateStatement()
        overrides and generates a bankstatement 
    public override bool Deposit(decimal amount)
        deposits money 
    public override bool Withdraw(decimal amount)
    protected override void RecordTransaction(Transaction transaction)
    public override decimal GetBalance()







public class SavingsAccount : Account
    public List<Transaction> Transactions { get; } = new List<Transaction>();
    constructor SavingsAccount() {}

Methods:
    public override string GenerateStatement()
        overrides and generates a bankstatement 
    public override bool Deposit(decimal amount)
        deposits money 
    public override bool Withdraw(decimal amount)
    protected override void RecordTransaction(Transaction transaction)
    public override decimal GetBalance()





public class Transaction
    public DateTime Date { get; protected set; }
    public decimal Credit { get; protected set; }
    public decimal Debit { get; protected set; }
    public decimal Balance { get; protected set; }

Constructor
    public Transaction(DateTime date, decimal credit, decimal debit)
    {
        Date = date;
        Credit = credit;
        Debit = debit;
        Balance = balance;
    }







