| Entity          | Attributes                               | Methods                                                      | Relationships                              |
|------------------|-----------------------------------------|-------------------------------------------------------------|-------------------------------------------|
| Customer        | `id`, `name`, `phoneNumber`             | `createAccount(type)`, `requestOverdraft(accountId)`, `viewStatement(accountId)` | Has many Accounts                         |
| Account         | `id`, `type`, `branchId`, `customerId`  | `deposit(amount)`, `withdraw(amount)`, `getBalance()`        | Belongs to Customer, has many Transactions |
| CurrentAccount  | `overdraftLimit`, `approvedOverdraft`   | `approveOverdraft(limit)`, `calculateAvailableFunds()`       | Inherits from Account                     |
| SavingsAccount  | `interestRate`                         | `calculateInterest()`, `addInterest()`                      | Inherits from Account                     |
| Branch          | `id`, `name`, `address`                | `addAccount(account)`, `listAccounts()`                     | Has many Accounts                         |
| Transaction     | `id`, `date`, `amount`, `type`         | `createTransaction(amount, type)`, `getTransactionDetails()` | Belongs to Account                        |
| Statement       | `id`, `accountId`, `generatedDate`     | `generate(accountId)`, `sendToPhone(customerPhoneNumber)`    | Includes many Transactions                |
     |
