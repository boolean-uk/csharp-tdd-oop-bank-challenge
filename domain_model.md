Class:	Customer		Method: AddAccount(AccountType CurrentAccount)			Case: Customer wants to create a current account to store money
Class:	Customer		Method: AddAccount(AccountType SavingsAccount)			Case: Customer wants to create a savings account to save money
Enum:	AccountType		Memebers: {CurrentAccount, SavingsAccount}				Case: Ensure only offered account types are made
Class	Account		Method: Deposit(double funds)								Case: Customer wants to put money in account
Class	Account			Method: Withdraw(double funds)							Case: Customer wants to take money out of the account
Class	Transaction		Method: GetDetails()									Case: Customer wants to get dates, amounts, and balance at the time of transaction
Class	Account			Method: GenerateBankStatement()							Case: Customer wants to get the details of each transaction of an account
Class	SavingsAccount implements Account
Class	CurrentAccount implements Account


```
As a customer,
So I can safely store use my money,
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
```

## Acceptance Criteria

**Given** a client makes a deposit of 1000 on 10-01-2012  
**And** a deposit of 2000 on 13-01-2012  
**And** a withdrawal of 500 on 14-01-2012  
**When** she prints her bank statement  
**Then** she would see:

```
date       || credit  || debit  || balance
14/01/2012 ||         || 500.00 || 2500.00
13/01/2012 || 2000.00 ||        || 3000.00
10/01/2012 || 1000.00 ||        || 1000.00
```