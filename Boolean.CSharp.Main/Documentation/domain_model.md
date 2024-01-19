# Core

| Classes | Fields | 
|-|-|
| `IAccount` (*abstract*) | `TransactionManager _transactions` `List<User> authorizedUsers` `decimal _balance` |
| `GeneralAccount` (implementes Account) | |
| `SavingsAccount` (implementes Account) | |
| `TransactionManager` | `List<DateTime, desimal> transactions` |
| `User` (*interface*) | | 
| `Customer` (*abstract*)(implements User) | `List<IAccount> accounts` `string Name` `DateTime birthDate` `DateTime lastLogin` |
| `Manager` (implements User) | `List<Customer> customers` `string Name` | 

| Classes | Method | Scenario | Outputs | 
|-|-|-|-|
| `Account` | `Deposit(desimal amount)` | Deposit money into the account | True |
| | | Failed to deposit money into the account | False | 
| | `Withdraw(desimal amount)` | Withdraw an amount out of the account | decimal | 
| | `GenerateTransactionRecord(DateTime start, DateTime end)` | Generate a detailed transaction record for the account | Out/Console | 
| | `GetBalance()` | Retrieve the current balance of the account | decimal | 
| | `AddUserToAccount(User user)` | Add a new user to the account | true | 
| | | Failed to add new user to the account | false | 
| `GeneralAccount` | | | 
| `SavingsAccount` | | |
| `IUser` | `GetName()` | Retrieve the name of the user | string |
| | `GetAccounts()` | Retrieve a list of all accounts associated with the user | List<Account> |
| | `AddAccountToUser(IAccount account)` | Add the account to the user object | true |
| | | Failed to add the account to the user | false | 
| `Customer` | `GetAge()` | Retrieve the customers age | int | 
| | `OpenNewAccount(string accountType)` | Generate a new account associated with the user | True |
| | | Failed to generate a new account | False | 
| `Manager`  | `GetCustomers()` | Retrieve a list of customers associated with this manager | List<Customer> | 
| `TransactionManager` | `PrintTransactions(DateTime start, DateTime end)` | Print the transaction record between the provided DateTimes | Out/Console | 