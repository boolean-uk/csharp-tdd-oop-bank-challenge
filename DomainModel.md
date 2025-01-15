## Domain Model



- You must demonstrate object-oriented principles. You need not include every concept, but you should strive to include as many as possible
- You can decide whether to use composition, inheritance, or a combination of both, but at least one must be present



| Classes    | Methods/Properties     | Scenario                                                                              | Outputs                                                     |
|------------|------------------------|---------------------------------------------------------------------------------------|-------------------------------------------------------------|
|            | CurrentAccount()       | Creating a current account                                                            |                                                             |
|            | SavingsAccount()       | Create a savings account                                                              |                                                             |
|            | GenerateStatement()    | Generate bank statements                                                              | String Transaction date, decimal amount and decimal balance |
|            | DepositOrWithdraw()    | Deposit and withdraw funds                                                            |                                                             |
|            | CalculateBalance()     | Account balances calculated based on transaction history (instead of stored in memory | Decimal Account balance                                     |
| Enums.cs   | Branches()             | Accounts associated with specific branches                                            |                                                             |
|            | RequestOverdraft()     | Request overdraft on my account                                                       | String approval/rejected eller boolean true/false           |
|            | ApproveOrReject()      | Approving or rejecting overdraft requests                                             |                                                             |
|            | SendStatementMessage() | Statements sent as messages to my phone                                               | String StatementMessage                                     |