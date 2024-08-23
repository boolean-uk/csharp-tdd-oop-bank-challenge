| Classes     | Methods                                                            | Scenario                                                                           | Outputs |
|-------------|--------------------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Account`   | `Account(ICustomer owner, IBranch branch, bool current)`           | Create an account linked to the given customer, branch, and if current or savings  | ----    |
|             | `Deposit(decimal amount)`                                          | Deposit money to account                                                           | void    |
|             | `Withdraw(decimal amount)`                                         | Withdraw money from account                                                        | true    |
|             |                                                                    | Cannot withdraw the given amount                                                   | false   |
|             | `Transactions()`                                                   | List out all transactions performed on the account                                 | string  |
|             | `Balance()`                                                        | Return the balance of the account, calculated from the transaction history         | decimal |
|-------------|--------------------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Saving`    | `Saving(ICustomer owner, IBranch branch)`                          | Create a savings account linked to the given customer and branch                   | ----    |
|             | `Deposit(decimal amount)`                                          | Override the deposit method in Account                                             | void    |
|             | `Withdraw(decimal amount)`                                         | Override the withdraw method in Account                                            | bool    |
|-------------|--------------------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Current`   | `Current(ICustomer owner, IBranch branch)`                         | Create a current account linked to the given customer and branch                   | ----    |
|             | `Deposit(decimal amount)`                                          | Override the deposit method in Account                                             | void    |
|             | `Withdraw(decimal amount)`                                         | Override the withdraw method in Account                                            | bool    |
|-------------|--------------------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `Bank`      | `Bank()`                                                           | Create a bank that keeps track of all the registered accounts                      | ----    |
|             | `CreateSaving(ICustomer customer, IBranch branch)`                 | Create a savings account of a branch and owned by the customer                     | true    |
|             |                                                                    | This customer already has a savings account                                        | false   |
|             | `CreateCurrent(ICustomer customer, IBranch branch)`                | Create a current account of a branch and owned by the customer                     | true    |
|             |                                                                    | This customer already has a current account                                        | false   |
|             | `HandleOverdraft(ICustomer customer, decimal amount)`              | Handle the overdraft requested from the customer. Only works on current accounts   | true    |
|             |                                                                    | Overdraft was denied                                                               | false   |
|             | `HandleDeposit(ICustomer customer, decimal amount, bool current)`  | Deposit the specified amount to account (true = current | false = saving)          | void    |
|             | `HandleWithdraw(ICustomer customer, decimal amount, bool current)` | Withdraw the specified amount from account (true = curren | false = saving)        | true    |
|             |                                                                    | Cannot withdraw more money than the existing amount                                | false   |
|-------------|--------------------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `ICustomer` | `GetName()`                                                        | Return the name of the customer                                                    | string  |
|-------------|--------------------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| `IBranch`   | `GetAllowedOverdraft()`                                            | Return the maximum allowed overdraft from this branch                              | decimal |
|-------------|--------------------------------------------------------------------|------------------------------------------------------------------------------------|---------|