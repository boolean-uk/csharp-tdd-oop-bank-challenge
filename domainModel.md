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
|                          | getBankStatement()      | Generates a bank statement with dates, amounts and balance at time of transaction | string |
|                          | Deposit(double amount)  | Deposits money into the account Returns true if transaction successful            | bool   |
|                          | Withfraw(double amount) | Withdraws mony from the account Returns true if transaction successful            | bool   |