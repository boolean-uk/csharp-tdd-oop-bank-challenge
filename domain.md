| Classes     	| Methods                            	| Scenario                                                                               	| Outputs               	|
|-------------	|------------------------------------	|----------------------------------------------------------------------------------------	|-----------------------	|
| Iperson.cs  	| CreateCurrentAccount()             	| creates a current account where the person is the owner                                	|                       	|
| Iperson.cs  	| CreateSavingsAccount()             	| creates an savings account                                                             	|                       	|
| Iperson.cs  	| GenerateBankStatements()           	| generates a bank statement int the terminal, sends to sms if SMS forwarding is enabled 	| string bankstatement; 	|
| Iaccount.cs 	| Deposit(float amount)              	| Deposit money to the account                                                           	|                       	|
| Iaccount.cs 	| Withdraw(float amount)             	| Withdraws money from the account                                                       	|                       	|
| Iaccount.cs 	| CalculateBalance()                 	| takes transaction history and calculates balance                                       	| float balance;        	|
| Ibank.cs    	| AddCustomer(string ssn)            	| Creates a person object in the bank branch                                             	|                       	|
| Iperson.cs  	| RequestOverdraft(Iaccount account) 	| creates a ticket which can be approved or denied by manager                            	| Request request;      	|
| Iperson.cs  	| ApproveOverdraft(Request request)  	| Takes a ticket and approves it, setting overdraft value to positive in account         	|                       	|
| Iperson.cs  	| ActivateSmsStatements()            	| everyTime a statement is generated, it is sent to the users phone                      	|                       	|
|             	|                                    	|                                                                                        	|                       	|