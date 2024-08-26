# Domain model for the bank challenge 

### User stories: 
```
1.
As a customer,
So I can safely store use my money,
I want to create a current account.

2.
As a customer,
So I can save for a rainy day,
I want to create a savings account.

3.
As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

4.
As a customer,
So I can use my account,
I want to deposit and withdraw funds.

5.
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

6.
As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

7.
As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

8.
As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

9.
As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.

```

#### Print: 
```
date       || credit  || debit  || balance
14/01/2012 ||         || 500.00 || 2500.00
13/01/2012 || 2000.00 ||        || 3000.00
10/01/2012 || 1000.00 ||        || 1000.00
```

#### Domain model: 
 
| Classes   | Methods | Scenario | Outputs |
|-----------|---------|----------|---------|
|`IAccount` | AccountNumber;||string|
|			| Balance;	||decimal|
|			| Deposit(decimal amount);| | void |
|			| Withdraw(decimal amount);|| void |
|			| GetTransactions;||List<ITransactions.>|
|			| GenerateStatement;||string|
|`CurrentAccount : IAccount`|CurrentAccount()| The cunstroctur creates a random account number||
|							|Deposit(decimal amount)|Adds an amount to the accounts balance, and creates a deposit transaction|void|
|							|Withdraw(decimal amount)|Removes an amount from the accounts balance, and creates a withdrawal transaction|void|
|							|GetTransactions()|returns the accounts transactions| List<Transaction. >|
|							|GenerateStatements()|Generates a return statement that includes transaction date, amounts and balance| string|
|`SavingsAccount : IAccount`|SavingsAccount()| The cunstroctur creates a random account number||
|							|Deposit(decimal amount)|Adds an amount to the accounts balance, and creates a deposit transaction|void|
|							|Withdraw(decimal amount)|Removes an amount from the accounts balance, and creates a withdrawal transaction|void|
|							|GetTransactions()|returns the accounts transactions| List<Transaction. >|
|							|GenerateStatements()|Generates a return statement that includes transaction date, amounts and balance| string|
|`ITransaction`| TransactionDate; ||DateTime|
|			   | Amount; ||decimal|
|			   | Type;		|| string|
|		       | BalanceAfterTransaction; || decimal|
| `Transaction : ITransaction` | | Implements ITransaction interface||
| `Customer` | CreateAccount(string accountType) | Creates an account of type current or savings| IAccount|
|		     | SendStatement(string statement) | Sends a statement as a message to the customers phone| void?|
|		     | SendOverdraftRequest(string accountnr)|The customer request an overdraft on its account|string|
|`Manager`	 | OverdraftRequest(string accountnr) |The manager approves an overdraft request  | true|	
||												  |The manager rejects an overdraft request|false|