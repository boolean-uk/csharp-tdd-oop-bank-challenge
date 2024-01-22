
| Classes         | Members                                         | Methods                                                      | Scenario                            | Outputs					 |
|-----------------|-------------------------------------------------|--------------------------------------------------------------|-------------------------------------|---------------------------|
| 'Account'(abstract) | GuId AccountID								|                                                              |                                     |                             |
|                  | double balance 								|															   |                                     |							   |
|				   | DateTime date									|															   |                                     |							   |
|				   |												|'deposit(double amount)		                               | deposit money to an account	     |	double					   |
|				   |												|'withdraw(double amount)		                               | withdraw money from an account	     |	double					   |
|				   |                                                | 'getDateTimeForTransaction()'                                | return time of a transaction	     |	DateTime			       |
|                  |                                                | createAccount();											   | Creates a account					 | Account




|'SavingsAccount : Account'  | Customer customer                    |                                                              |                                     |                              |
|                            |                                      | SavingsAccount(Customer customer);						   | Creates a account		             | account                      |

|'CurrentAccount : Account'  | Customer customer                    |                                                              |                                     |                              |
|                            |                                      | CurrentAccount(Customer customer);						   | Creates a account		             | account                      |


|'Customer'        | GuId CustomerID								|                                                              |                                     |                             |
|                  | string name    								|															   |                                     |							   |


Customer : some base user class 

int id
string firstname
string lastname
list Accounts 
double (Balance) 
list transactionsHistory


deposit 
withdraw
overdraft
getText()

Account (current / savings) 

int id
string name/Type
string branch

createCurrentAccount(Customer customer, AccountType);
	
createSavingsAccount(Customer customer, AccountType);

deposit 

withdraw

overdraft 


BankTransaction
int id 
tranType transactionType (inn /ut) 
tranType status 
Datetime time 
decimail amount 
decimal newBalance 
deciaml oldBalance 


Bank Manager  : some base user class


int id
string firstname
string lastname
