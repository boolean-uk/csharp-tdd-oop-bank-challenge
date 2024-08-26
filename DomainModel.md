# User stories:

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


# Domain model
|----------------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------|------------------------------|
| Classes                          | Methods											                       | Scenario                                                       | Outputs                      |
|----------------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------|------------------------------|
| Account (abstract)               | deposit(decimal amount)                                                   | customer deposits money                                        |                              |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  | withdraw(decimal amount)                                                  | customer withdraws money                                       |                              |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  | getBalance()                                                              | customer wants to see how much money exists in the account     | decimal                      |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  | printStatement()                                                          |                                                                | string                       |
|                                  |                                                                           |                                                                |                              |
|                                  | RequestOverdraft()                                                        | Customer request an overdraft                                  |                              |
|                                  |                                                                           |                                                                |                              |
|                                  | RequestToTransaction()                                                    | Request gets accepted and customer is able to withdraw         |                              |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|----------------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------|------------------------------|
| Transaction                      | Public Transaction(decimal Amount, DateTime date, TransactionType type)   |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|----------------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------|------------------------------|
| CurrentAccount : Account         |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|----------------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------|------------------------------|
| SavingsAccount : Account         |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|----------------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------|------------------------------|
| Person                           | Public Person(string name, Role role, Bank? bank)                         | Person can be either a manager, customer or engineer           |                              |
|                                  |                                                                           | ? is for when the person works at the bank as the manager      |                              |
|                                  |                                                                           |                                                                |                              |
|                                  | addAccount(Account account)                                               | Person adds an account                                         |                              |
|                                  |                                                                           |                                                                |                              |
|                                  | answerOverdraft(Person person, OverdraftRequest request)                  | Accepts/declines the request based on role                     |                              |
|                                  |                                                                           |                                                                |                              |
|----------------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------|------------------------------|
| Bank                             | Public Bank(string name, decimal EmergencyFund)                           | Creates a new bank object with a set fund                      |                              |
|                                  |                                                                           |                                                                |                              |
|                                  | addBranch(Branch branch)                                                  | Adds a specific branch to a bank                               |                              |
|                                  |                                                                           |                                                                |                              |
|                                  | getAllBranches()                                                          | Bank wants to see all connected branches                       | List<Branch>                 |
|                                  |                                                                           |                                                                |                              |
|                                  | moneyLeftInFund()                                                         | Bank wants to see how much money is left in the emergency fund | decimal                      |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|----------------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------|------------------------------|
| Branch                           | addAccount(Account account)                                               | Adds a specific account to a branch                            |                              |
|                                  |                                                                           |                                                                |                              |
|----------------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------|------------------------------|
|                                  |                                                                           |                                                                |                              |
| OverdraftRequest                 | Public OverdraftRequest(decimal amount, Account account)                  | Customer creates a request for a potential overdraft           |                              |
|                                  |                                                                           |                                                                |                              |
|                                  | Accept()                                                                  | Accepts the request                                            |                              |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|----------------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------|------------------------------|
| Enums                            | Public Enum Role(CUSTOMER, ENGINEER, BANK_MANAGER)                        |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  | Public Enum TransactionType(CREDIT, DEBIT)                                |                                                                |                              |
|                                  |                                                                           |                                                                |                              |
|                                  | Public Enum OverdraftStatus(ACCEPTED, DECLINED)                           | might be redundant for the current methods                     |                              |
|                                  |                                                                           |                                                                |                              |
|----------------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------|------------------------------|