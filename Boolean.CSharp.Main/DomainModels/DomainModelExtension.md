As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.



-----------------------------------------------------------------------------------------------
|Classes:				| Methods:									| Scenario		| Output	|
|						|											|				|			|
|						|											|				|			|
|`Accounts`(Parent)		|`Deposit(Transactions transaction)`		|				|void		|
|`CurrentAccount`(Child)|`Withdraw(Transactions transaction)`		|				|void		|
|`SavingsAccount`(Child)|`getBalance()`								|				|int		|
|						|`printStatement()`							|				|void		|
|						|`RequestOverdraft()`						|				|			|
|						|`FixODrequest()`							|				|			|
|						|											|				|			|
|						|											|				|			|
|`Enums`				|`TransactionTypes`							|				|			|
|						|`Branches`									|				|			|
|						|`OverdraftRequests`						|				|			|
|`OverdraftRequest`		|											|				|			|
|`Transaction`			|											|				|			|
|						|											|				|			|
-----------------------------------------------------------------------------------------------