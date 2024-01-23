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
                | CalculateBalance()                      | loops through BankTransactions adds amount based on credt/debit to sum        | decimal balanse
                | RequestOverdraft() 
                | _overdraftRequest                        |sort bankTransaction to sort pending or denied transactcions to own register in Account
                | GenerateBankStatement()                  | sort by Date, print data to rows

Saving:Account  |
Current:Account |

BankTransaction | Id, Date, Amount, TransactionType |  
                |  int Id { get; set; }
                |  TransactionType Type { get; set; }
                |  DateTime Date { get; set; }
                |  double Amount { get; set; }
                |  double NewBalance { get; set; }
                |  double OldBalance { get; set; }
                |TransactionStatus in BankTransaction (pending, approved, denied)
                   
	        User| Abstract? //divide in userclasses?(Extensions) 
                | int Id
                | userTypes              | "Manager","Customer","Engineer", 
                | Manager.GetOverdraftRequests() | gets list - sets requests to approved or rejected, set new Date | returns Transaction to correct List<Transaction>

Bank            | GenerateUserId()                      | uniqueID ++                                                                       | int
            

 
Extension User stories

As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.
=> Account.CalculateBalance()

As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.
=> Enum branches
=> Bank List<accoun

As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.
=> RequestOverdraft() 
=> TransactionStatus in BankTransaction (pending, approved, denied)
=> sort bankTransaction to sort pending or denied transactcions to own register in Account

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.
==> account.OverdraftRequests{get;}
==> set status to rejected or Approved - if Approved => set new date and send to _bankTransaction
==> sort print by date

As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.
==> Message class
==> Telio