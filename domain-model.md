# Domain Model 

# User Stories 

1.
As a customer,
So I can safely store use my money,
I want to create a current account.

2. 
1. As a customer,
So I can save for a rainy day,
I want to create a savings account.

3.
As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

4.
As a customer,
So I can use my account,
I want to deposit and withdraw funds.

Domain Model 1: Basic Bank Account System
Class	Method	Scenario	Output
Account	Deposit(amount)	Deposit $1000 into the account	Balance: $1000
Account	Withdraw(amount)	Withdraw $500 from the account	Balance: $500
Account	GenerateStatement()	Generate a bank statement after transactions	List of transactions
Account	CalculateBalance()	Calculate the current balance	Balance: $500
Account	SendStatementToPhone(phoneNumber)	Send statement to a phone	Message sent to the phone
BankStatement	AddTransaction(transaction)	Add a transaction to the statement	Updated list of transactions
BankStatement	GenerateReport()	Generate a report from transactions	Formatted report
Transaction	(No methods)	(Data container)	N/A