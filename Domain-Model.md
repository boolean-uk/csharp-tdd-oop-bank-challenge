Domain Model - Bank Challenge

## User Stories

```
As a customer,
So I can safely store use my money,
I want to create a current account.
=> current : Account

As a customer,
So I can save for a rainy day,
I want to create a savings account.
=> saving : Account

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
=> 
class Bankstatments
List<bankStatements> inkludes id, Date, credit/debit amount, balance
=> dew
As a customer,
So I can use my account,
I want to deposit and withdraw funds.
=> deposit(), withdraw()

Class			|	Methods/Members		                  |	Scenario				                                    		      	  |output		
abstract Account|   List<BankTransactions> BankTransaction| includes instances of BankTransaction, Date, credit/debit amount, balance     |    
                |   Id, AvailableAmount, type             |
                |    Deposit(amount)                      |new BankTransaction => AvailableAmount + amount                                |Account.BankTransactionList.Add( BankTransaction )                         
                |   Withdraw(amount)                      |if amount < AvailableAmount => new BankTransaction => AvailableAmount - amount |Account.BankTransactionList.Add( BankTransaction )  
Saving:Account  |
Current:Account |

BankTransaction | Id, Date, Amount, TransactionType |  
                |  int Id { get; set; }
                |  TransactionType Type { get; set; }
                |  DateTime Date { get; set; }
                |  double Amount { get; set; }
                |  double NewBalance { get; set; }
                |  double OldBalance { get; set; }
                   
	        User| Abstract? //divide in userclasses?(Extensions) 
                | int Id
                | userTypes              | "Manager","Customer","Engineer", 

Bank            | GenerateUserId()                      | uniqueID ++                                                                       | int
                
