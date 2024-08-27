| Package |Class                                      | Method                                 | Scenario                                 | Output  |
---------------|-------------------------------------------|----------------------------------------|------------------------------------------|---------|
| `Model`       | `Model`                                   | `createPerson`                         |                                          |         |
|               |                                           | `createBankAccount`                    |                                          | |
|               |                                           | `requestOverdraft`                     |                                          | |
|               |                                           | `approveOverdraftRequest`              |                                          | |	
|               |                                           | `getOverdraftRequests`                 |                                          | |
|               |                                           | `getBankAccount`                       |                                          | |
|               |                                           | `getCustomers`                         |                                          | |
|               |                                           | `withdrawMoneySavings`                 |                                          | |
|               |                                           | `withdrawMoney`                        |                                          | |
|               |                                           | `depositMoneySavings`                  |                                          | |
|               |                                           | `depositMoney`                         |                                          | |
|               | `Bank`  "Has all model methods"           |                                        |                                          | |
|               | `BankAccount` "Has most model methods"    | `getBankId`                            |                                          | |
|               |                                           | `getBankStatements`                    |                                          | |
|               |                                           | `getDate`                              |                                          | |
|               |                                           | `getBalanceSavings`                    |                                          | |
|               |                                           | `getBalanceTransac`                    |                                          | |
|               | `BankStatement` "Only get set"            |                                        |                                          | |
|               | `Customer` "Only get set"                 |                                        |                                          | |
|               | `OverdraftRequest`                        | `approve`                              |                                          | |
|               |                                           | `getAmount`                            |                                          | |
|               |                                           | `getCustomerID`                        |                                          | |
|               |                                           | `getIsApproved`                        |                                          | |
|               |                                           | `getReason`                            |                                          | |
|               | `SavingsAccount`                          |                                        |                                          | |
|               | `TransactionalAccount`                    |                                        |                                          | |
| `View`        | `View`"Contains prints and no real logic" |                                        |                                          | |
| `Controller`  | `Controller` "Contains methods to pass data between model and view, basically copies of what exists in model"                            |                                        |                                          | |
