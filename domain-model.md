# Core User Stories
1. As a customer, so I can store my money safely, I want to create a current account.
2. As a customer, so I can save for a rainy day, I want to create a savings account.
3. As a customer, so I can keep a record of my finances, I want to generate bank statements with transaction dates, amounts, and balance at the time of the transaction.
4. As a customer, so I can use my account, I want to deposit and withdraw funds.

# Extension User Stories
5. As an engineer, so I don’t need to keep track of state, I want account balances to be calculated based on transaction history instead of being stored in memory.
6. As a bank manager, so I can expand, I want accounts to be associated with specific branches.
7. As a customer, so I have an emergency fund, I want to be able to request an overdraft on my account.
8. As a bank manager, so I can safeguard our funds, I want to approve or reject overdraft requests.
9. As a customer, so I can stay up to date, I want statements to be sent as messages to my phone.

# Domain Model

| Classes                       | Methods                                             | Scenario                                | Outputs                                                                    |
|-------------------------------|-----------------------------------------------------|-----------------------------------------|----------------------------------------------------------------------------|
| Core.BankAffiliate            | CreateCurrentAccount(BankAccount account)           | Add a current account                   | Returns true if account is successfully added, false if duplicate          |
| Core.BankAffiliate            | CreateSavingsAccount(BankAccount account)           | Add a savings account                   | Returns true if account is successfully added, false if duplicate          |
| Core.BankAffiliate            | DepositFunds(BankAccount account, double amount)    | Deposit funds into an account           | Adds a deposit transaction, updates the transaction list                   |
| Core.BankAffiliate            | WithdrawFunds(BankAccount account, double amount)   | Withdraw funds from an account          | Adds a withdrawal transaction, updates the transaction list                |
| Core.BankStatement            | GenerateBankStatement(BankAccount account)          | Generate a bank statement               | Returns a formatted string of transaction history                          |
| Extension.BankAccount         | GetBalance                                          | Calculate balance based on transactions | Returns the calculated balance as a double                                 |
| Extension.BankAccount         | RequestOverdraft(double limit)                      | Request an overdraft                    | Returns true if overdraft request is recorded, sets the overdraft limit    |
| Extension.BankAccount         | ApproveOverdraft(BankAccount account, double limit) | Approve or reject an overdraft request  | Returns true if overdraft is approved, false otherwise                     |
| Extension.MessageNotification | SendStatement(Extension.BankAccount account)        | Send a bank statement as a message      | Returns a formatted string message containing the account's bank statement |