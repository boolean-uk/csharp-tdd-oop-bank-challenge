
| Classes         | Members                                         | Methods                                                      | Scenario                            | Outputs					 |
|-----------------|-------------------------------------------------|--------------------------------------------------------------|-------------------------------------|---------------------------|
| 'Account'(abstract) | GuId AccountID								|                                                              |                                     |                             |
|                  | double balance 								|															   |                                     |							   |
|                  | string branch  								|															   |                                     |							   |
|				   | List<BankTransaction> transactions           	|															   |                                     |							   |
|				   |												|'deposit(double amount)		                               | deposit money to an account	     |	double					   |
|				   |												|'withdraw(double amount)		                               | withdraw money from an account	     |	double					   |
|				   |                                                | 'addTransaction(BankTransaction transaction)'                | add transaction to a list  	     |	void    			       |
|                  |                                                | 'GetBalance()'											   | get account balance				 |  double					   |
|                  |                                                |                                                              |                                     |
|'SavingsAccount : Account'  | Customer customer                    |                                                              |                                     |                              |
|                            |                                      | SavingsAccount(Customer customer);						   | Creates a account		             | account                      |
|'CurrentAccount : Account'  | Customer customer                    |                                                              |                                     |                              |
|                            |                                      | CurrentAccount(Customer customer);						   | Creates a account		             | account                      |
|'Customer'        | GuId CustomerID								|                                                              |                                     |                              |
|                  | string name    								|															   |                                     |							    |
|                  |                								|															   |                                     |							    |
|'BankTransaction  |     	              							|															   |                                     |							    |
|				   | int id    	              					    |															   |                                     |							    |
|                  | Date date    	              					|															   |                                     |							    |
|           	   | double newBalance		              			|						                                	   |                                     |							    |
|                  | double oldBalance    	              			|															   |                                     |							    |
|                  | double amount   	              				|															   |                                     |							    |
|                  | string transactionType    	              		|															   |                                     |							    |
|                  |     	              							|															   |                                     |							    |
|                  |     	              							|															   |                                     |							    |
|                  |     	              							|															   |                                     |							    |
|                  |     	              							|															   |                                     |							    |





