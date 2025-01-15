Customer, So I can safely store use my money, I want to create a current account.

Customer,
So I can save for a rainy day,
I want to create a savings account.

Customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

Customer,
So I can use my account,
I want to deposit and withdraw funds.

Engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

Bank manager,
So I can expand,
I want accounts to be associated with specific branches.

Customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

Bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

Customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.

* Two account types: Savings and current
* Generate statement with transaction dates, amount, and balance
* Allow deposit withdraw funds
* Calculate balance from history
* Account associated with branches (branch enum)
* Allow for overdraft up to specified amount
* Manager sets overdraft amount
* Send message to phone

## Classes

Account: 
  - bool Withdraw(double amount)
  - void Deposit(double amount)
  - double Balance {get}
  - private List<Transaction>
  - double AllowedOverdraft
  - bool ChangeOverdraft(User managerUser)
  - string Name (name should be unique)

AdminAccount : User:
 

Transaction (double amount, TransactionType type, DateTime transactionTime);
User:
  - List<Account> GetAccounts();
TransactionType {Withdrawal, Deposit}

