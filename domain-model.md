```
As a customer,
So I can safely store use my money,
I want to create a current account.

As a customer,
So I can save for a rainy day,
I want to create a savings account.

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

As a customer,
So I can use my account,
I want to deposit and withdraw funds 
```

```
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.
```


  | Classes                 | Methods										 	      | Scenario					       	                                  | Outputs 			    
  |-------------------------|---------------------------------------------------------|----------------------------------------------------------------------------------------------------------------|
  | enum AccountType        |                                                         | store account types                                                   | Current, Savings
  -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
  | enum Branch             |                                                         | stores branches as strings                                            | Bergen, Oslo, Trondheim, Stavanger
  -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
  | Account                 | AccountType Type                                        |                                                                       |        
  |					        | TransactionType Type                                    |                                                                       |
  |					        | List<Transaction>                                       | store all account transactions                                        | List<Transactions>
  |                         | decimal Balance                                         | store account balance (credit, debit)                                 | decimal       
  |                         | Branch branch                                           | the branch associated with the account                                |        
  |                         | overDraftActive = false                                 | bool to see if overdraft from account is possible                     | bool       
  |					        | Deposit(decimal Amount, TransactionType)                | adds amount to account balance. Create deposit transaction.           | bool 
  |					        | Withdraw(decimal Amount, TransactionType)               | removes amount from account balance. Create withdrawal transaction.   | bool						
  |					        | GenerateBankStatement()	                              | generate statement with transcation date, amount, balance 	 		  | void
  |                         | makeOverdraft()                                         | if customer, if approved by manager                                   |				
  | CurrentAccount : Account| 		                                                  | overrides AccountType                                                 | Current
  | SavingsAccount: Account |			                                              | overrides AccountType                                                 | Savings
  -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
  | enum TransactionType    |                                                         | store transaction types                                               | Deposit, Withdraw
  -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
  | Transaction             | DateTime Date                                           | store transaction date                                                | DateTime date
  |					        | TransactionType Type                                    | store type of transaction                                             | Deposit, Withdraw
  |					        | decimal Amount                                          | store transaction amount (deposit, withdraw)                          | decimal
  |					        | decimal Balance                                         | store balance after transaction                                       | decimal
  -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
  | Customer                | List<Account>	                                       	  | Store customer accounts                                               | List<Account>
  |                         | createAccount(Account, Branch branch, Customer)         | Creates account of type current or savings 	                          | bool
  | Manager                 | handleOverdraftRequest(Account account, decimal amount) |                                                                       | bool
  |			



  
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           +

