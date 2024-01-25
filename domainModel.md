
# Bank Challenge Domain Model

## Customer
| Field          | Type   | Description          |
| -------------- | ------ | -------------------- |
| `name`         | string | Full name of the customer. |

## BankAccount (Abstract Class)
| Field          | Type                | Description |
| -------------- | ------------------- | ----------- |
| `transactions` | ITransactionManager | Contains a record of transactions on this account. |

| Property       | Type    | Description |
| -------------- | ------- | ----------- |
| `Balance`      | decimal | Calculated from ITransactionManager |

| Method                 | Return Type | Parameters          | Description |
| ---------------------- | ----------- | ------------------- | ----------- |
| `ApplyTransaction`     | void        | `ITransaction`      | Applies a transaction to the account. |

## CurrentBankAccount : BankAccount
In current bank accounts, overdraft transactions are allowed.

| Method                    | Return Type | Parameters          | Description |
| ------------------------- | ----------- | ------------------- | ----------- |
| `ApplyOverdraftTransaction`| void        | `ITransaction`      | Applies a transaction as an overdraft transaction, which has to be approved before it goes through. |

## SavingsBankAccount : BankAccount
Savings accounts do not allow overdraft transactions.

## BankAccountManager
| Field               | Type                                    | Description |
| ------------------- | --------------------------------------- | ----------- |
| `customerAccounts`  | Dictionary<Customer, List<BankAccount>> | Associates BankAccounts with Customers. |

| Method                | Return Type         | Parameters                  | Description |
| --------------------- | ------------------- | --------------------------- | ----------- |
| `LinkAccountToCustomer`| void               | `Customer, BankAccount`     | Adds the given BankAccount to the given Customer in customerAccounts. |
| `GetCustomerAccounts`  | List<BankAccount>  | `Customer`                  | Returns a list of BankAccounts associated with a the given Customer. |

## ITransaction (Interface)
| Property       | Type    | Description |
| -------------- | ------- | ----------- |
| `Amount`       | decimal | The amount being transferred. |
| `Date`         | DateTime| Timestamp of when the transaction was made. |

| Method             | Return Type | Description |
| ------------------ | ----------- | ----------- |
| `EffectOnBalance`  | decimal     | A signed version of the amount being applied to the bank account. |

## DebitTransaction : ITransaction
Amount is subtracted from balance.

## CreditTransaction : ITransaction
Amount is added to balance.

## OverdraftTransaction : ITransaction
| Field                | Type         | Description |
| -------------------- | ------------ | ----------- |
| `underlyingTransaction` | ITransaction | The transaction waiting to be approved. |
| `isApproved`            | bool         | The current status of the overdraft transaction request. |

| Method        | Return Type | Description |
| ------------- | ----------- | ----------- |
| `Approve`     | void        | Approves the request, and changes amount to that of the underlying transaction. |

## ITransactionManager (Interface)
| Method            | Return Type | Parameters               | Description |
| ----------------- | ----------- | ------------------------ | ----------- |
| `AddTransaction`  | void        | `ITransaction`           | Adds an ITransaction to the transaction manager. |
| `GetTransactions` | List<ITransaction> | `DateTime, DateTime` | Retrieves a list of transactions between two points in time. |
| `CalculateBalance`| decimal     |                          | Returns the sum of all the transactions. |

## TransactionManager : ITransactionManager
| Field           | Type               | Description |
| --------------- | ------------------ | ----------- |
| `transactions`  | List<ITransaction> | Holds a list of transactions. |

## IBankStatement (Interface)
| Property        | Type         | Description |
| --------------- | ------------ | ----------- |
| `Account`       | BankAccount  | The account of the bank statement. |

| Method            | Return Type | Description |
| ----------------- | ----------- | ----------- |
| `GenerateStatement` | string    | Returns a receipt of all transactions between two points in time. |
