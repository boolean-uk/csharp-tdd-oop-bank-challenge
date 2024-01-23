| Classes					| Members																				| Properties							| Methods										| Scenario														| Outputs			|
|---------------------------|---------------------------------------------------------------------------------------|---------------------------------------|-----------------------------------------------|---------------------------------------------------------------|-------------------|
| `BankSystem`				| `List<IUser> users`																	|										|												|																|					|
| `IUser`					|																						|										|												|																|					|
| `CustomerUser`			| `List<ABankAccount> _accounts`														|										| `CreateAccount(ABankAccount)`					| User wants to make a current account							| string			|
|							|																						|										|												| User wants to make a savings account							| string			|
|							|																						|										| `Withdraw(double, int)`						| User attempts to withdraw more than possible					| false				|
|							|																						|										|												| User attempts to withdraw an acceptable ammount				| true				|
|							|																						|										| `Deposit(double, int)`						|																| double			|
|							|																						|										| `GenerateStatement(int)`						|																| string			|
| 							|																						|										| `CheckBranch(int)`							|																| string			|
|							|																						|										| `RequestOverdraft(double, int)`				|																| OverdraftRequest	|
|							|																						|										| `SendAccountText(int)`						|																|					|
| `ManagerUser`				|																						|										| `ManageRequest(OverdraftRequest, eStatus)`	| Overdraft is approved											| string			|
|							|																						|										|												| Overdraft is denied											| string			|
| `ABankAccount`			| `List<BankStatement> _transactions`													|										| `Transaction(BankStatement)`					|																| double			|
|							| `enum eBranch`																		|										| `Money()`										|																| double			|
| 							| `List<OverDraftRequest> _overdrafts`													|										| `WriteTransactions()`							|																| StringBuilder		|
|							|																						|										| `Overdraft()`									|																|					|
|							|																						|										| `SendTextMessage(ITextMessageSender)`			|																|					|
| `CurrentAccount`			|																						|										|												|																|					|
| `SavingsAccount`			|																						|										|												|																|					|
| `BankStatement`			| `DateTime _transactionDate`															| `double Transaction{ get;}`			|												|																| double			|
|							| `double creditDebit`																	|										|												|																|					|
|							| `bool valid`																			|										|												|																|					|
|							| `enum eType`																			|										|												|																|					|
| `OverDraftRequest`		|																						| `double Amount{get; set}`				|												|																|					|
|							|																						| `DateTime RequestDate{get; set}`		|												|																|					|
|							|																						| `enum Stauts RequestStatus{get; set}`	|												|																|					|
| `ITextMessageSender`		|																						|										| `SendMessage(string)`							|																|					|
| `TwilioMessageProvider`	|																						|										| `SendMessage(string)`							|																|					|
| *							|																						|										|												|																|					|
