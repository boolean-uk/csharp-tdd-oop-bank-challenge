User Stories
1. As a customer, So I can safely store use my money, I want to create a current account.
2. As a customer, So I can save for a rainy day, I want to create a savings account.
3. As a customer, So I can keep a record of my finances, I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
4. As a customer, So I can use my account, I want to deposit and withdraw funds.

Extension User stories
5. As an engineer, So I don't need to keep track of state, I want account balances to be calculated based on transaction history instead of stored in memory.
6. As a bank manager, So I can expand, I want accounts to be associated with specific branches.
7. As a customer, So I have an emergency fund, I want to be able to request an overdraft on my account.
8. As a bank manager, So I can safeguard our funds, I want to approve or reject overdraft requests.
9. As a customer, So I can stay up to date, I want statements to be sent as messages to my phone.


| Classes			| Members												| Methods							| Scenario										| Output
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Branch			| string BranchName { get; set; }						|									| property for branch name						|
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Account			| List<Account> MyAccounts								|  									| list of accounts								| 
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Account			| List<Transaction> MyTransactions						|									| lsit of transactions							|
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Account			|														| CreateAccount(Account account)	| adds new account								| 
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Account			|														| MakeDeposit(decimal amount)		| if deposit add to balance						| bool
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Account			|														| MakeWithdrawal(decimal amount)	| if withdrawal subtract from balance			| bool
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Account			|														| GenerateBankStatement()			| generate string of bank statement				|
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Account			| string AccountType { get; set; }						|									| property to get account type					| string
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Account			| string Branch { get; set; }							|									| set Branch associated with account			|
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Account			| PrintBankStatement { get; set; }						| 									| property to get bank statement				| string
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| CurrentAccount	| 														| CurrentAccount()					| constructor									|
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| SavingsAccount	| 														| SavingsAccount()					| constructor									|
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Transaction		|														| Transaction()						| constructor									|
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


| Interfaces        |
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| ITransaction		| dateTime Date { get; set; }							|									| property to get date and time of transaction	| DateTime
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| ITransaction		| decimal Amount { get; set; }							|									| property to get amount of deposit or withdraw	| decimal
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| ITransaction		| decimal Balance { get; set; }							|									| property to get account balance				| decimal
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| ITransaction		| string TransactionType { get; set; }					|									| property to get transaction type				| string
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
