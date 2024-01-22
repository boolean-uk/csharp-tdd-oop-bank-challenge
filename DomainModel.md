//Bank Account Challenge

Class:
	BankAccount
Properties:
	public readonly int: currentBallance
	public readonly list<int>: balanceList
	private list<Transaction>: TransactionsList
	public readonly string: AccountID
Methods:
	MakeTransaction(Transaction, transaction);
		//Creates a transaction object
		//Executes transaction and updates balance/balancelist
	GetBankStatement();
		//Generates bankstatement of current status

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