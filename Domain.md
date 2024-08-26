|Classes                  |Methods                        |Scenarios               |Outputs      |
|_________________________|_______________________________|________________________|_____________|
|Account                  |Account(int customerId,        |Account created         |----         |
|						  |int accountNum, IBranch branch)|						   |			 |
|						  |								  |						   |			 |
|                         |Deposit(double funds)          |Funds deposited and     |void    	 |
|                         |                               |recorded on history     |			 |
|                         |                               |						   |             |
|                         |Withdraw(double funds)         |Funds withdrawn and 	   |void         |
|                         |                               |recorded on history     |             | 
|                         |                               |                        |			 |
|                         |GenerateStatement()            |Prints out bank         |string		 |
|                         |                               |Statements              |			 |
|					      |					              |						   |			 |
|                         |Balance()                      |Calculates balance from |double		 |
|                         |                               |History            	   |			 |
|_________________________|_______________________________|________________________|_____________|
|Current : Account        |                               |                        |     		 |
|_________________________|_______________________________|________________________|_____________|
|Savings : Account        |								  |      				   |			 |
|_________________________|_______________________________|________________________|_____________|
|Manager                  |SetOverdraftLimit(double funds |Overdraft limit set     |void   	     |                                                                                                                                                                                                      
|                         |, Bank bank)                   |                        |             |                                                                                                                     
|_________________________|_______________________________|________________________|_____________|
|Bank                     |CreateAccount(int customerId   |Customer creates a new  |int          |                            
|                         |, IBranch branch, bool         |bank account            |             |                                                                        
|                         |savingsAccount)                |                        |             |    
|                         |                               |Customer does not exist |-1           |                                   
|                         |                               |                        |             |     
|                         |RequestWithdraw(int customerId |Customer withdraws money|true         |                                                         
|                         |double funds, int accountNumber|                        |             |                       
|                         | bool overdraw)                |Customer does not exist |false        |                                                        
|                         |                               |                        |             |     
|                         |                               |Customer does not have  |             |                            
|                         |                               |savings/current account |false        |                                 
|                         |                               |                        |             |     
|                         |                               |Customer does not have  |false        |                                 
|                         |                               |sufficient funds in the |             |                             
|                         |                               |account and overdraw is |             |                            
|                         |                               |denied.                 |             |            
|                         |                               |                        |             |     
|                         |RequestDeposit(int customer    |Customer deposits money |true         |                                                         
|                         |double funds,int accountNumber)|into account            |             |                                             
|                         |                               |                        |             |             
|                         |                               |Customer does not exist |false        |                                 
|                         |                               |                        |             |     
|                         |                               |Customer does not have  |             |                            
|                         |                               |savings/current account |false        |                                 
|                         |                               |                        |             |     
|                         |                               |Customer does not have  |false        |                                 
|                         |                               |sufficient funds to     |             |                         
|                         |                               |deposit the requested   |             |                                                                                                                                 
|                         |                               |amount                  |             |           
|                         |                               |                        |             |     
|                         |RequestBankStatement(int       |Prints bank statement   |string       |                                                             
|                         |customerId, int accountNUmber) |                        |             |                               
|                         |                               |                        |             |     
|                         |CreateCustomer(Customer custom)|Creates a new customer  |true         |                                                             
|                         |                               |                        |             |     
|                         |                               |Customer already exists |false        |                                                                                                                                      
|_________________________|_______________________________|________________________|_____________|                                                                                                          
|Customer                 |Customer(double funds)         |                        |----         |                                                                                                                                            
|_________________________|_______________________________|________________________|_____________|                                                                                                                                                                                   
