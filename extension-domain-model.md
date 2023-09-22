# Extension Domain Model 

# User Stories 

1.
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

2.
As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

3.
As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

4.
As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

5.
As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.

Class	Method	Scenario	Output
Account	Deposit(amount)	Deposit $1000 into the account	Balance: $1000
Account	Withdraw(amount)	Withdraw $500 from the account	Balance: $500
Account	GenerateStatement()	Generate a bank statement after transactions	List of transactions
Account	CalculateBalance()	Calculate the current balance	Balance: $500
Account	SendStatementToPhone(phoneNumber)	Send statement to a phone	Message sent to the phone
BankStatement	AddTransaction(transaction)	Add a transaction to the statement	Updated list of transactions
BankStatement	GenerateReport()	Generate a report from transactions	Formatted report
Transaction	(No methods)	(Data container)	N/A
SavingsAccount	CalculateInterest()	Calculate interest and add to balance	Balance with interest added
CurrentAccount	RequestOverdraft(amount)	Request an overdraft	Balance with overdraft applied