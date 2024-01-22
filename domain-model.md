| Classes			| Members																				| Properties					| Methods							| Scenario														| Outputs		|
|-------------------|---------------------------------------------------------------------------------------|-------------------------------|-----------------------------------|---------------------------------------------------------------|---------------|
| `BankSystem`		| `List<IUser> users`																	|								|									|																|				|
| `IUser`			|																						|								|									|																|				|
| `CustomerUser`	| `List<ABankAccount> _accounts`														|								| `CreateAccount(ABankAccount)`		| User wants to make a current account							| string		|
|					|																						|								|									| User wants to make a savings account							| string		|
|					|																						|								| `Withdraw(double, int)`			| User attempts to withdraw more than possible					| false			|
|					|																						|								|									| User attempts to withdraw an acceptable ammount				| true			|
|					|																						|								| `Deposit(double, int)`			|																| double		|
|					|																						|								| `GenerateStatement()`				|																| int			|
|					|																						|								| `RequestOverdraft(double)`		|																| BankStatement	|
| `ManagerUser`		|																						|								| `ManageRequest(BankStatement)`	|																| bool			|
| `ABankAccount`	| `List<BankStatement> _transactions`													|								| `Transaction(BankStatement)`		|																| double		|
|					| `enum eBranch`																		|								| `WriteTransactions()`				|																| string		|
| `CurrentAccount`	|																						|								|									|																|				|
| `SavingsAccount`	|																						|								|									|																|				|
| `BankStatement`	| `DateTime _transactionDate`															| `double Transaction{ get;}`	|									|																| double		|
|					| `double creditDebit`																	|								|									|																|				|
|					| `bool valid`																			|								|									|																|				|
|					| `enum eType`																			|								|									|																|				|
| *					|																						|								|									|																|				|
