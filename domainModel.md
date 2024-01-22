| Classes         | Methods                         |  Returns  | Scenario               | Outputs					   | 
|-----------------|---------------------------------|-----------|-------------------------|----------------------------|
|`Customer`	| `CreateSavingsAccount(string name)`		| string	| customer doesn't have an account with the same name	| confirmation that new account has been made	|
|			| 											| string	| customer has an account with the same name			| message that account couldn't be made and to change the name	|
|			| `CreateCurrentAccount(string name)`		| string	| customer doesn't have an account with the same name	| confirmation that new account has been made	|
|			| 											| string	| customer has an account with the same name			| message that account couldn't be made and to change the name	|
|			| `GenerateStatement()`						| string	| 														| Generates a table of all withdrawals and deposits of 'customer's accounts	|
|			| `Deposit(string account, double amount)`	| string	|														| funds are added to account and returns new balance |
|			| `Withdraw(string account, double amount)`	| string	| customer has enough funds	in account					| funds are withdrawn from account and returns new balance	|
|			|											|			| customer doesn't have enough funds in account			| funds are not withdrawn and returns warning |
|`Account`	| `GetBalance()`							| double	|														| returns the balance of the account |
|			| `Deposit(double amount)`					| string	|														| funds are deposited to account and returns new balance |
|			| `Withdraw(double amount)`					| string	| customer has enough funds	in account					| funds are withdrawn from account and returns new balance |
|			|											| string	| customer doesn't have enough funds in account			| funds are not withdrawn and returns warning |
|			| `GenerateStatement()`						| string	| 														| Generates a table of all withdrawals and deposits of account|