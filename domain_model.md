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

| Classes			| Methods                                       | Scenario               | Outputs  |
|-------------------|-----------------------------------------------|------------------------|----------|
| `abstract Account`| `Account(): Account`						    |						 |void	    |
|					| `Deposit(Transaction transaction)`		    |						 |void		|
|					| `Withdraw(Transaction transaction)`			|						 |void		|
|					| `PrintStatement()`							|						 |string	|
| `CurrentAccount`	| `CurrentAccount(): Account`				    |						 |void	    |
| `SavingsAccount`	| `SavingsAccount(): Account`				    |						 |void		|
| `BankTransaction`	| `BankTransaction(string type, decimal amount)`	|					     |void		|

```
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
```

| Classes			| Members                                       | Scenario               | Outputs  |
|-------------------|-----------------------------------------------|------------------------|----------|
| `abstract Account`| `Account(): Account`						    |						 |		    |
|					| `AccountName: String`						    |						 |		    |
|					| `Branch: Branches`						    |						 |		    |
|					| `OverDraftRequests: List<OverDraftRequests>`	|						 |		    |
|					| `Transactions: List<BankTransactions>`	    |						 |		    |
|					| `Deposit(Transaction transaction)`		    |						 |void		|
|					| `Withdraw(Transaction transaction)`			|						 |void		|
|					| `PrintStatement()`							|						 |string	|
|					| `CalculateBalance()`							|						 |string	|
|					| `RequestOverdraft(decimal amount)`	   		|						 |string	|
|					| `HandleORRequest(int id, overdraftstatus status)`|					 |void		|
| `CurrentAccount`	| `CurrentAccount(User user): Account`			|						 |void	    |
|					| `Customer: User`								|						 |		    |
| `SavingsAccount`	| `SavingsAccount(User user): Account`			|						 |void		|
|					| `Customer: User`								|						 |		    |
| `BankTransaction`	| `BankTransaction(enum type, decimal amount, decimal balance)`|		     |void		|
|					| `Type: TransactionType`						|					     |			|
|					| `Created: DateTime`							|					     |			|
|					| `Amount: decimal`								|					     |			|
|					| `balance: decimal`							|					     |			|
|`abstract User`	| `FirstName: string`							|					     |			|
|					| `LastName: string`							|					     |			|
|					| `Address: string`								|					     |			|
|					| `Id: Guid`									|					     |			|
|`OverDraftRequest`	| `OverDraftRequest()`							|					     |void		|
|					| `id: int`										|					     |			|
|					| `amount: decimal`								|					     |			|
|					| `Account: Account`							|					     |			|
|					| `Status: enum`								|					     |			|


