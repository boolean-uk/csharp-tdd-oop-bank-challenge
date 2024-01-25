# Bank Challenge Domain Model
## Classes/Interfaces

### Customer
#### Fields
* **`name: string`** - Full name of the customer.

### BankAccount (Abstract Class)
#### Fields
* **`transactions: ITransactionManager`** - Contains a record of transactions on this account.
#### Properties
* **`Balance: decimal`** - Calculated from ITransactionManager

#### Methods
* **`ApplyTransaction(ITransaction): void`** - Applies a transaction to the account.

### CurrentBankAccount : BankAccount

### SavingsBankAccount : BankAccount

### BankAccountManager
#### Fields:
* **`customerAccounts: Dictionary<Customer, List<<BankAccount>>`** - Associates BankAccounts with Customers.
#### Methods:
* **`LinkAccountToCustomer(Customer, BankAccount): void`** - Adds the given BankAccount to the given Customer in customerAccounts.
* **`GetCustomerAccounts(Customer): List<BankAccount>`** - Returns a list of BankAccounts associated with a the given Customer.


### ITransaction (Interface)
#### Properties
* **`Amount: decimal`** - The amount being transferred.
* **`Date: DateTime`** - Timestamp of when the transaction was made.
#### Methods
* **`EffectOnBalance(): decimal`** - A signed version of the amount being applied to the bank account.

### DebitTransaction : ITransaction

### CreditTransaction : ITransaction

### ITransactionManager (Interface)
#### Methods
* **`AddTransaction(ITransaction): void`** - Adds an ITransaction to the transaction manager.
* **`GetTransactions(DateTime, DateTime): List<ITransaction>`** - Retrieves a list of transactions between two points in time.
* **`CalculateBalance(): decimal`** -Returns the sum of all the transactions.
### TransactionManager : ITransactionManager
#### Fields
* **`transactions: List<ITransaction>`** - Holds a list of transactions.

### IBankStatement (Interface)
#### Properties
* **`Account: BankAccount`** - The account of the bank statement.
#### Methods
* **`GenerateStatement(): string`** - Returns a receipt of all transactions between two points in time.
