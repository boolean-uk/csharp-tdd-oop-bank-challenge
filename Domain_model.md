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

enum accountType: currentAccount, savingsAccount

Class: Customer
private List<Account> accounts

Methods:
public Account createAccount(int accountNr, string type)
return: createdAccount

Abstract Class: Account
public list<Transaction> transaction
private int accountNr
private float balance

Methods:
public Transaction withdraw(float amount)
public Transaction deposit(float amount)
public void printStatement()

Class: SavingsAccount : Account

Class: CurrentAccount : Account

enum transactionType: deposit, withdraw

Class: Transaction
private float amount
private float newBalance
private string transactionType
private DateTime timeStamp

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