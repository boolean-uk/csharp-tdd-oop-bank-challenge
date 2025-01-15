# Domain Model

| Entity          | Attributes                               | Relationships                              |
|------------------|-----------------------------------------|-------------------------------------------|
| Customer        | `id`, `name`, `phoneNumber`             | Has many Accounts                         |
| Account         | `id`, `type`, `branchId`, `customerId`  | Belongs to Customer, has many Transactions |
| CurrentAccount  | `overdraftLimit`, `approvedOverdraft`   | Inherits from Account                     |
| SavingsAccount  | `interestRate`                         | Inherits from Account                     |
| Branch          | `id`, `name`, `address`                | Has many Accounts                         |
| Transaction     | `id`, `date`, `amount`, `type`         | Belongs to Account                        |
| Statement       | `id`, `accountId`, `generatedDate`     | Includes many Transactions                |
