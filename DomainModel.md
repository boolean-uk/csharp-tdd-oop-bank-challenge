//Bank Account Challenge

Class:
	BankAccount
Properties:
	public float: currentBalance {get; private set;}
	public list<int>: balanceList {get; private set;}
	public list<Transaction>: transactionsList {get; private set;}
	public string: accountID {get; private set;}
	public string: Branch {get; private set;}
Methods:
	MakeTransaction(Transaction, transaction);
		//Creates a transaction object
		//Executes transaction and updates balance/balancelist
	GetBankStatement();
		//Generates bankstatement of current status
	SetBranch(string branch)
		//sets branch

Class: 
	CurrentAccount: BankAccount
Properties:
	public readonly string: typeOfAccount
Methods:
	CurrentAccount()
		typeOfAccount = "CurrentAccount"

Class:
	SavingsAccount: BankAccount
Properties:
	public readonly string: typeOfAccount
Methods:
	SavingsAccount()
		typeOfAccount = "SavingsAccount" 

Class:
	Transaction
Properties:
	public readonly string: date
	public readonly float: ammount
	public readonly string: transactionType
	public readonly string: transactionID
Methods:
	Transaction(float ammount)