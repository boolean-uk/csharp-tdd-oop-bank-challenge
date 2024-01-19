As a customer,
So I can safely store my money,
I want to create a current account.

As a customer,
So I can save for a rainy day,
I want to create a savings account.

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

As a customer,
So I can use my account,
I want to deposit and withdraw funds.

Given a client makes a deposit of 1000 on 10-01-2012
And a deposit of 2000 on 13-01-2012
And a withdrawal of 500 on 14-01-2012
When she prints her bank statement
Then she would see:
	date       || credit  || debit  || balance
	14/01/2012 ||         || 500.00 || 2500.00
	13/01/2012 || 2000.00 ||        || 3000.00
	10/01/2012 || 1000.00 ||        || 1000.00

Class: Customer

Methods:
public void createAccount(int accountNr)

Class: Account
private string type
private int accountNr
private float balance
public float amount

Methods:
public void withdraw(int accountNr, float amount)
public void deposit(int accountNr, float amount)

Class: Transaction : Account
private float amount
private string transactionType
private DateTime timeStamp

Methods:
public string createTransaction()

Class: BankStatement
public list<Transaction> transaction

Methods:
public void printStatement()

______________________
TYPE	DESCRIPTION  |
<|--	Inheritance  |
*--		Composition  |
o--		Aggregation  |
-->		Association  |
--		Link (Solid) |
..>		Dependency   |
..|>	Realization  |
..		Link (Dashed)|