# Domain Model

## User Stories

```
As a customer,
So I can safely store and use my money,
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
```
| Class          | Method                            | Member                           | Scenario                            | Return                |
|----------------|-----------------------------------|----------------------------------|-------------------------------------|-----------------------|
| Branch	     | Name()							 | String name						| Get branch name					  | Branch name           |
| Customer		 | CustomerID()						 | Integer customerId				| Get customer ID                     | Customer ID           |
|                | CurrentAccount()					 | Current Account  				| Get Curren account                  | currentAccount        |
|                | SavingsAccount()					 | Savings Account  				| Get Savingsaccount                  | savingstAccount       |
| Account		 | setCustomer(customer)			 | Customer							| Set customer to account             |                       |
|        		 | Deposit(amount)				     | Double amount					| Add deposit to account              | Return true           |
|        		 | Withdraw(amount)				     | Double amount					| Withdraw from account               | return true           |
|        		 |								     |									| Not enough funds                    | return false          |
|        		 | Balance()					     | List transaction					| Get current balance                 | Double sum            |
|        		 | Transactions()				     | List transaction					| Get all transactions                | List transactions     |
|        		 | Balance()					     | List transaction					| Get current balance                 | Double sum            |
|        		 | Branch()						     | Branch							| check branch		                  | branch                |
|        		 | setOverDrawAmount(overDrawAmount) | Double overDrawAmount			| Insufficient balance                | return false          |
|        		 |								     |									| Set new overdrawft amount           | return true           |
| CurrentAccount |								     | Branch							|							          |		                  |
| SavingsAccount |								     | Branch							|							          | Branch                |
|				 | Withdraw(amount)				     | Double amount					| Withdraw from account		          | return true           |
|        		 |								     |									| Not enough funds                    | return false          |
| BankStatement	 | printStatement()					 | Account, Transaction				| Get history and balance             | String                |
| Transaction	 | Date()							 |									| Get date of transaction             | DateTime              |
|				 | Amount()							 |									| Get amount of transaction           | Double amount         |
|				 | Type()							 |									| Get type of transaction             | String                |
