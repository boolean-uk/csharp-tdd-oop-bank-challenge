## Domain Model

1: ``` As a customer, So I can safely store use my money, I want to create a current account. ```

2: ``` As a customer, So I can save for a rainy day, I want to create a savings account.```

3: ``` As a customer, So I can keep a record of my finances, I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction. ```

4: ``` As a customer, So I can use my account, I want to deposit and withdraw funds. ```

Req:	| Class: (.cs)	 | Method/Properties:																			| Scenario:									| Output:										|
--------|----------------|----------------------------------------------------------------------------------------------|-------------------------------------------|-----------------------------------------------|
		| Program		 | Starts the BankingApp																		| Running the app							| Application									|
		| BankingApp	 | `BankingApp()`																				| Main method for the app, navigation menu	| Console										|
		| BankingApp	 | `Logo()`																						| Bank Logo									| Prints Logo									|
		| BankingApp	 | `Welcome()`																					| First navigation menu						| Console										|
		| BankingApp	 | `NewClient()`																				| New customer registration					| Customer										|
		| BankingApp	 | `GetHiddenPassword()`																		| Client enters password (invisible)		| String										|
		| BankingApp	 | `CredentialCheck()`																			| Log-in menu: username + password			| Access or no access							|
		| BankingApp	 | `PersonalAccount(ProvidedUsername)`															| Personal account menu with options		| Navigation choice								|
		| BankingApp	 | `ViewAccounts(ProvidedUsername)`																| Overview of client accounts + options	    | Navigation choice								|
		| BankingApp	 | `CheckingMenu(ProvidedUsername)`																| Access checking account + options			| Navigation choice								|
		| BankingApp	 | `OverdraftSettings(AccountNumber, ProvidedUsername)`											| Change overdraft settings (only checking)	| New overdraft limit							|
		| BankingApp	 | `SavingsMenu(ProvidedUsername)`																| Access savings account + options			| Navigation choice 							|
		| BankingApp	 | `DepositMenu(AccountNumber)`																	| Deposit to account						| Transaction added to Account in AccountList   |
		| BankingApp	 | `WithdrawMenu(AccountNumber)`																| Withdraw from account						| Transaciont added to Account in AccountList   |
		| BankingApp	 | `CreateCheckingAccount(ProvidedUsername)`													| Create a new checking account				| CheckingAccount							    |	
		| BankingApp	 | `CreateSavingsAccount(ProvidedUsername)`														| Create a new savings account				| SavingsAccount								|
		| BankingApp	 | `AccountNumberGenerator()`																	| Generates new account nr (random based)	| String										|
		| BankingApp	 | `Stop()`																						| Stops the application						|												|
		|				 |																								|											|												|	
		| Customer		 | `Customer(Name, Address, Password)`															| Frame for customer						| Object										|
		| CustomerList   | List of Customers																			| List that app uses while active			| List											|
		| CustomerList	 | `OpenCustomerFile()`																			| Reads existing customer file				| Void											|
		| CustomerList	 | `AddNewCustomer(newcustomer)`																| Adds new customer to CustomerList	+ file	| Void		  									|
		| CustomerList	 | `AddExistingCustomer(newcustomer)`															| Adds existing customer to CustomerList	| Void		  									|
		| CustomerList	 | `CheckCustomerName(username)`																| Name check against CustomerList			| Bool		  									|
		| CustomerList	 | `CheckPassword(username, password)`															| Password check when entering credentials	| Bool		  									|
		|				 |																								|											|												|
		| Account		 | Account(accountNumber, customerName, startBalance, accountType, allowOverdraft, transactions)| Frame for each account					| Object	  									|
		| Account		 | `GetBalance()`																				| Gets the balance of an account			| Float		  									|
		| CheckingAccount| Account																						| Class for checking accounts				| Object	  									|
		| SavingsAccount | Account																						| Class for savings accounts				| Object	  									|
		| AccountList	 | List of Accounts																				| List that the app uses while active		| List		  									|
		| AccountList	 | `AddNewAccount(newaccount)`																	| Add new checking/savings account to List  | Void		  									|
		| AccountList	 | `LoadExistingAccounts()`																		| Refreshes accountList from file			| List		  									|
		| AccountList	 | `WriteAccountstoFile()`																		| Writes current accountList to file		| Textfile	  									|
		| AccountList	 | `ViewcustomerAccounts(ProvidedCustomer)`														| Shows customers accounts in personal menu | Void		  									|
		| AccountList	 | `CustomerHasAnyAccount(ProvidedCustomer)`													| Check if customer has any accounts		| Bool		  									|
		| AccountList	 | `CustomerHasCheckingAccount(ProvidedCustomer)`												| Check if customer has checking account	| Bool		  									|
		| AccountList	 | `CustomerHasSavingsAccount(ProvidedCustomer)`												| Check if customer has savings account		| Bool		  									|
		| AccountList	 | `AccessCheckingAccount(ProvidedCustomer)`													| Display accountnr + balance for checking  | Bool		  									|
		| AccountList	 | `GetCheckingAccountNr(ProvidedCustomer)`														| Get checkingaccountnr for menu			| String	  									|
		| AccountList	 | `AccessSavingsAccount(ProvidedCustomer)`														| Display accountnr + balance for savings	| Bool		  									|
		| AccountList	 | `GetSavingsAccountNr(ProvidedCustomer)`														| Get savingsaccountnr for menu				| String	  									|
		| AccountList	 | `ViewTransactionHistory(accountnumber)`														| Display transaction history				| Void		  									|
		| AccountList	 | `DepositAmount(accountnumber, amount)`														| Make a deposit							| Void		  									|
		| AccountList	 | `WithdrawAmount(accountnumber, amount)`														| Make a withdrawal							| Void		  									|
		| AccountList	 | `ActivateOverdraft(accountnumber, newfloorstring, accountType)`								| Change the overdraft amount				| Void		  									|
		| Transaction	 | `Transaction(Amount, Datetime)`																| Frame for transactions					| Object	  									|

Extension

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