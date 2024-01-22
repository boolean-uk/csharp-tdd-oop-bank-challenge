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
I want to deposit and withdraw funds.,

| Class                    | Method                  | Scenario                                                                          | Output |
|--------------------------|-------------------------|-----------------------------------------------------------------------------------|--------|
| SavingsAccount : Account |                         |                                                                                   |        |
| CurrentAcount : Account  |                         |                                                                                   |        |
| Account                  | Create()                | Creates and account                                                               | void   |
|                          | getBankStatement()      | Generates a bank statement with dates, amounts and balance at time of transaction | void   |
|                          | Deposit(double amount)  | Deposits money into the account Returns true if transaction successful            | bool   |
|                          | Withdraw(double amount) | Withdraws mony from the account Returns true if transaction successful            | bool   |

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

| Class                    | Method             | Scenario                                                                          | Output |
|--------------------------|--------------------|-----------------------------------------------------------------------------------|--------|
| SavingsAccount : Account |                    |                                                                                   |        |
| CurrentAcount : Account  |                    |                                                                                   |        |
| Account                  | Savings()          | Returns total value on the Account, a cumulative sum over previous transactions   | double |
|                          | Branch()           | Returns the branch that the account is associated with                            | enum   |
|                          | RequestOverdraft() | Request access to overdrafting an account                                         | void   |
|                          | AcceptOverdraft()  | If overdraft requested, accept it and return true,  if not requested return false | bool   |
|                          | RejectOverdraft()  | If overdraft requested, reject it and return true,  if not requested return false | bool   |
|                          | SendStatement()    | Sends generated bank statement to phone                                           | void   |