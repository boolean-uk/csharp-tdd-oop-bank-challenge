C O R E

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



| Classes              | Members                             | Methods                                                | Scenario                                           | Outputs   |
|----------------------|-------------------------------------|--------------------------------------------------------|----------------------------------------------------|-----------|
| `Account (Abstract)` | List<ITransaction> _transactions    |                                                        | 						                           |           |
|                      | Customer _customer                  |                                                        | 						                           |           |
|                      |                                     | decimal Deposit(double amount)                         | 						                           | double    |
|                      |                                     | decimal Withdraw(double amount)                        | 						                           | double    |
| `AccountCurrent`	   |                                     | void RequestOverdraft(double amount)                   | 						                           |           |
| `AccountSavings`     |                                     |                                                        | 						                           |           |
| `Customer`	       |                                     |                                                        | 						                           |           |
| `ITransaction`	   |  Guid.Id                            |                                                        | 						                           |           |
|                      |  enum.TransactionType.Type          |                                                        | 						                           |           |
|                      |  enum.TransactionStatus.Status      |                                                        | 						                           |           |
|                      |  DateTime.Date                      |                                                        | 						                           |           |
|                      |  decimal.Amount                     |                                                        | 						                           |           |
|                      |  decimal.NewBalanc                  |                                                        | 						                           |           |
|                      |  decimal.OldBalance                 |                                                        | 						                           |           |
|                      |                                     |                                                        | 						                           |           |
|                      |                                     |                                                        | 						                           |           |
|                      |                                     |                                                        | 						                           |           |
|                      |                                     |                                                        | 						                           |           |


 
 E X T E N S I O N

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


| Classes              | Members                             | Methods                                                | Scenario                                           | Outputs   |
|----------------------|-------------------------------------|--------------------------------------------------------|----------------------------------------------------|-----------|
| `Account (Abstract)` | enum.Branch.Branch                  |                                                        | 						                           |           |
|                      |                                     |                                                        | 						                           |           |
|                      |                                     | decimal GetBalance()                                   | 						                           | double    |
