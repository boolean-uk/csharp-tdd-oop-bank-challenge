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


Classes: BankAccount												|	BankTransaction
Enums:	Account { Current, Savings }								|	Transaction { Withdraw, Deposit } 
																	|	transaction { type, amount } ??
Functions:  Create_Account(string id, int balance, accounttype)		|	List<Transaction> TransactionHistory
			Write_Statement(date, cred_amount, deb_amount, balance)		
