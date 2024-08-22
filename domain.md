| Class    | Method                      | Scenario                                                          | Output               |
|----------|-----------------------------|-------------------------------------------------------------------|----------------------|
| Branch   | NewCustomer(Customer)       | Creates a new customer and adds them to this branch               | true if successful   |
|          |                             |                                                                   | false if not         |
| Branch   | GetCustomer(int customerId) | Looks for a customer based on their customer ID                   | Customer             |
|          |                             |                                                                   | null                 |
| Customer | CreateAccount(AccountType)  | Lets the customer create a new account                            | true if successful   |
|          |                             |                                                                   | false if not         |
| Customer | GetAccount(string name)     | Finds the account with corresponding name                         | Account              |
|          |                             |                                                                   | null                 |
| Account  | GetTransactions()           | Fetches the transaction statement for this account                | list of transactions |
| Account  | PrintTransactions(List)     | Print the list of transactions                                    | void                 |
| Account  | Deposit(decimal amount)     | Deposits the amount into the account                              | true if successful   |
|          |                             |                                                                   | false if not         |
| Account  | Withdraw(decimal amount)    | Withdraws the amount from the account                             | true if successful   |
|          |                             |                                                                   | false if not         |
| Account  | GetBalance()                | Calculates and returns the balance based on transaction statement | decimal              |
| Customer | RequestOverdraft(Account)   | Requests overdraft for a specific account                         | ture, success        |
|          |                             |                                                                   | false, error         |
| Manager  | ManageOverdraftRequests()   | Manages the overdraft requests                                    | void                 |
| Customer | SetSmsNotification(bool)    | Lets the customer decide if they want SMS updates or not          | void                 |

Core:
- As a customer, I want to create a current account, So I can safely store use my money.
- As a customer, I want to create a savings account, So I can save for a rainy day.
- As a customer, I want to generate bank statements with transaction dates, amounts,
    and balance at the time of transaction, So I can keep a record of my finances.
- As a customer, I want to deposit and withdraw funds, So I can use my account.

Exensions:
- As an engineer, I want account balances to be calculated based on transaction history
    instead of stored in memory, So I don't need to keep track of state.
- As a bank manager, I want accounts to be associated with specific branches, So I can expand.
- As a customer, I want to be able to request an overdraft on my account, So I have an emergency fund.
- As a bank manager, I want to approve or reject overdraft requests, So I can safeguard our funds.
- As a customer, I want statements to be sent as messages to my phone, So I can stay up to date
