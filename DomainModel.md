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
																	|	
Functions:  Create_Account(string id, int balance, accounttype)		|	List<Transaction> TransactionHistory
			Write_Statement(date, cred_amount, deb_amount, balance)		Create_Transaction(type, amount , account_id)	

As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

// I will add an enum Branch and Property to the accounts

As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

// I will add Overdraft_request method to set a new state on an Overdraft enum
// Overdraft will be available only in current accounts.

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

// I will add Qualify_Overdraft method for the manager to use
// It will Approve if the amount is under or equal 2000 or Reject if it is more

As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.