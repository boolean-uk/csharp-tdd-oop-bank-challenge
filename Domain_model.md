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

Class: Bank
string branch

Methods:
public float returnOverdraft
return: the approved overdraft if approved

public bool approveOverdraft
return: true if approved

enum accountType: currentAccount, savingsAccount

Class: Customer
private List<Account> accounts

Methods:
public Account createAccount(int accountNr, string type)
return: createdAccount


Abstract Class: Account
public list<Transaction> transactions
private int accountNr
private float overdraft

Methods:
public float total(List<Transaction> transactions(from account))
returns: combined "amounts" from all transaction entries for the account

public Transaction withdraw(float amount) take overdraft into consideration

public Transaction deposit(float amount)

public float requestOverdraft(float reqOverdraft)
return: reqOverdraft if approved

public void printStatement()


Class: SavingsAccount : Account

Class: CurrentAccount : Account

enum transactionType: deposit, withdraw

Class: Transaction
private float amount
private string transactionType
private DateTime timeStamp

Methods:

Extension:
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.

Mermaid arrow cheatsheet:
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