| Class					   | Method/Property						 | Scenario			   | Output			|
|--------------------------|-----------------------------------------|---------------------|----------------|
| Customer				   | CreateCurrentAccount()					 |					   | CurrentAccount |
|						   | CreateSavingsAccount()					 |					   | SavingsAccount |
|						   | Deposit(int id, decimal amount)		 |					   | string message | 
|	 					   | Withdraw( int id, decimal amount)		 |					   | string message	|
| Account				   | List < Transaction > TransactionHistory |					   |				|
|						   | Deposit(decimal amount)				 |					   |				| 
|	 					   | Withdraw(decimal amount				 | sufficent funds	   | string message	|
|						   |										 | not sufficent funds | string message |
|						   | BankStatement()						 |					   | string			|
| CurrentAccount : Account |										 |					   |				|
| SavingsAccount : Account |										 |					   |				|
| Transaction			   |										 |					   |				| 
