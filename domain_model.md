```
INFO: The acutal implementations use interfaces for each concrete class below, for extensibility.

Class:	Customer			Method: void AddAccount(Account)						Case: Customer wants to create a current account or a savings account to store money
Class:  Customer			Method: List<Account> GetAccounts()						Case: The customer wants to know all the accounts they have
Class:	Customer			Property: CreditScore           						Case: The bank manager wants to approve accounts, and must know the customers credit score
Enum:	CreditScore			Members: {VeryBad,Bad, Neutral, Good, VeryGood}			Case: The bank manager wants to approve accounts, and must know the customers credit score
Class:	SavingsAccount implements Account											Case: implemets the abstract Account class
Class:	CurrentAccount implements Account											Case: implemets the abstract Account class
Class:	Account				Method: void AddTransaction(Transaction)				Case: Customer wants to put money in account
Class:  Account				Method: double GetBalance()                             Case: Customer wants to know the balance of their account
Class:  Account				Method: bool OverdraftApproved()						Case: The bank manager wants to approve accounts, and must know the customers credit score
Class:	Account				Method: sting GenerateBankStatement()					Case: Customer wants to get the details of each transaction of an account
Class:  Account				Method: void SendBankstatementSMS()						Case: Customer wants bank statement sendt to their phone
Class:  Account				Property: Branch										Case: Bank manager want accounts associated with branches, for expansion
Enum:	Branch				Members: {Norway,Sweden, England}						Case: Bank manager want accounts associated with branches, for expansion
Class:	Transaction			Method: Tuple<DateTime, double, double> GetDetails()	Case: Customer wants to get dates, amounts, and balance at the time of transaction
Class:	Transaction			Method: void SetBalance(double)							Case: The balance of an account after transaction should be stored in the transaction object
Class:  Administrator		Method: void RequestOverdraft(Account)					Case: An account can request of admin to have overdraft enabled
Class:  Administrator		Method: void ApproveOverdraft(Customer, Account)		Case: The admin wants to approve accounts, and must know the customers credit score
Class:  Administrator		Method: void DisableOverdraft(Account)					Case: The admin wants the ability to disable overdrafts for an account 
```
