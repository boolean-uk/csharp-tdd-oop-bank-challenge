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



Create Current Account(Should be able to withdraw and save money to account)

Create Savings Account(Should be able to withdraw and save money to account)

Generate Bank Statements(Print out transaction dates, amounts, currentBalance)

Deposit Funds
Withdraw Funds

-----------------------------------------------------------------------------------------------
|Classes:				| Methods:
|						|
|`Bank`					|`createBankAccount()`
|						|
|`BankAccount`			|`createAccount()`
|						|
|`Accounts`(Parent)		|`Deposit(account, int)`
|						|`Withdraw(account, int)`
|						|
|`CurrentAccount`(Child)|
|`SavingsAccount`(Child)|
|						|
|						|
|						|