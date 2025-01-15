Core:
| Classes             | Methods                                                                         | Scenario                                        | Outputs                                  |
|---------------------|---------------------------------------------------------------------------------|-------------------------------------------------|------------------------------------------|
| Bank.cs             | CreateCustomer(string firstName, string lastName, string email, string address) | The bank creates/adds a customer to their bank  | Customer created!                        |
| Customer.cs         | CreateAccount(string accountType)                                               | Customer wants to create account(s)             | Account created!                         |
| Account.cs          | Deposit(decimal amount)                                                         | Customer wants to deposit to account            | Deposited amount to account!             |
| Account.cs          | Withdraw(decimal amount)                                                        | Customer wants to withdraw from account         | Withdrew amount from account!            |
| Account.cs          | GenerateStatement()                                                             | Customer wants a account statement              | AccountStatement object.                 |
| Account.cs          | DisplayStatement()                                                              | Customer wants to create and see the statement. | Displays formatted statement in console. |

Extensions:

| Classes           | Methods                                                              | Scenario                                                       | Outputs                                 |
|-------------------|----------------------------------------------------------------------|----------------------------------------------------------------|-----------------------------------------|
| Account.cs        | GetBalance()                                                         | Engineer wants balance calculated based on transaction history | Returns calculated account balance.     |
| Account.cs        | RequestOverdraft(decimal amount)                                     | Customer requests an overdraft                                 | Overdraft request sent for approval.    |
| Manager.cs        | ProcessOverdraftRequestOverdraftRequest request, bool isApproved)    | Bank manager wants to approve or reject an overdraft           | Overdraft approved or rejected message. |
| MessageService.cs | SendStatementToPhone(AccountStatement statement, string phoneNumber) | Customer wants statements sent as messages to their phone      | Statement sent as SMS.                  |
