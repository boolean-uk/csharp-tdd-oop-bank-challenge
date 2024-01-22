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
|                      |                                     | double Deposit(double amount)                          | 						                           | double    |
|                      |                                     | double Withdraw(double amount)                         | 						                           | double    |
| `AccountCurrent`	   | Customer _customer                  |                                                        | 						                           |           |
| `AccountSavings`     | Customer _customer                  |                                                        | 						                           |           |
| `Customer`	       |                                     |                                                        | 						                           |           |
| `Transaction`	       |                                     |                                                        | 						                           |           |


 