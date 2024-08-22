

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


----------------------------

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





| Classes         | Methods                                     | Scenario							 |			  Outputs								|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `IAccount		` | `										`	| Interface for accounts			 |													|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `Bank			 `| `CreateAccount(IAccount account)		`	| Creates account					 |(bool) True if removed, otherwise false			|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `SavingsAccount`| `CreateAccount()						`	| Remove item from basket, if exists |(bool) True if removed, otherwise false			|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `CheckingAccoun`| `CreateAccount()						 `	| Remove item from basket, if exists |(bool) True if removed, otherwise false			|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|
| `SavingsAccount`| `RemoveItem(Item item)					`	| Remove item from basket, if exists |(bool) True if removed, otherwise false			|
|                 |                                             |									 |													|
|-----------------|---------------------------------------------|------------------------------------|--------------------------------------------------|


