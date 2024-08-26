-- Core --
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
I want to deposit and withdraw funds.

-- Extension --
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



| Classes       | Methods			     	  |  Scenario								 | Outputs      |
| ------------- | -------------	     		  |  ------------							 | -----------  |
| `Bank`		| AddCustomer(Customer c)	  |  Adds new customer to the bank			 | true			|
|				|							  |	 Fails to add new customer to the bank   | false		|
|				|							  |									         |				|
| `Bank`		| RemoveCustomer(Customer c)  |  Removes customer from the bank			 | true			|
|				|							  |	 Fails to remove customer from the bank  | false		|
|				|							  |									         |				|
| `Bank`		| FindCustomer(int phonenr?)  |  Finds customer with the given number	 | Customer		|
|				|							  |	 Fails to find the customer				 | null			|
|				|							  |									         |				|
| `Bank`		| CreateAccount(Customer c, AccountType t, BankBranches b)   |  Creates a new account for customer 	 | BankAccount	|
|				|							  |									         |				|
| `Customer`	| FindBankAccount(int number) |  Finds account with given number	 	 | BankAccount	|
|				|							  |									         |				|
| `Customer`	| AddBankAccount(BankAccount b)					    |  Adds new account to customers account list	    	 					   | BankAccount		|
|				|													|																			   |					|
| `BankAccount` | MakeTransaction(BankTransaction tr) |  Makes transaction to account     | double newbalance  |
|               |												    |																			   |		    	    |
| `BankAccount` | ApprovedTransaction(BankTransaction tr) |  Approves, and adds an overdraft transaction request     | double newbalance  |
|               |												    |																			   |		    	    |
| `BankAccount` | GetBalance() |  Returns the bank account balance    | double balance  |
|               |												    |																			   |		    	    |
| `BankAccount` | SendTransaction() |  Sends transaction confirmation to sms    | void  |
|               |												    |																			   |		    	    |
| `BankAccount` | PrintTransactionHistory() |  Prints transactionhistory to console    | void  |
|               |												    |																			   |		    	    |
| `Manager    ` | GetOverdraftRequests()							|  Returns list of overdraftrequests    | List<Tuple<BankAccount,Banktransaction>> req  |
|               |												    |																			   |		    	    |
| `Manager    ` | ApproveRequest(Tuple<BankAccount, BankTransaction>>)	|  Approves the given transaction on the account    | void  |
|               |												    |																			   |		    	    |
