| Classes			| Members																				| Properties					| Methods							| Scenario														| Outputs		|
|-------------------|---------------------------------------------------------------------------------------|-------------------------------|-----------------------------------|---------------------------------------------------------------|---------------|
| `BankSystem`		| `List<IUser> users`																	|								|									|																|				|
| `IUser`			|																						|								|									|																|				|
| `CustomerUser`	| `List<ABankAccount> _accounts`														|								| `CreateAccount(ABankAccount)`		| User wants to make a current account							| string		|
|					|																						|								|									| User wants to make a savings account							| string		|
|					|																						|								| `Withdraw(double, ABankAccount)`	| User attempts to withdraw more than possible					| false			|
|					|																						|								|									| User attempts to withdraw an acceptable ammount				|				|
|					|																						|								| `Deposit(double, ABankAccount)`	|																| double		|
|					|																						|								| `RequestOverdraft(double)`		|																| BankStatement	|
| `ManagerUser`		|																						|								| `ManageRequest(BankStatement)`	|																| bool			|
| `ABankAccount`	| `List<BankStatement> _transactions`													|								| `Transaction(Transaction)`		|																| double		|
|					| `string _branch`																		|								| `WriteTransactions()`				|																| string		|
| `CurrentAccount`	|																						|								|									|																|				|
| `SavingsAccount`	|																						|								|									|																|				|
| `BankStatement`	| `DateTime _transactionDate`															| `double Transaction{ get;}`	|									|																| double		|
|					| `double creditDebit`																	|								|									|																|				|
|					| `bool valid`																			|								|									|																|				|
|					|																						|								|									|																|				|
|					|																						|								|									|																|				|
