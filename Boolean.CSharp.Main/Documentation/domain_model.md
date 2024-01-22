# Core

| Classes | Fields | 
|-|-|
| `IAccount` (*interface*) | `TransactionManager _transactions` `List<User> authorizedUsers` `decimal _balance` |
| `GeneralAccount` (implementes Account) | `IBankTransaction _transactions` `List<IUser> authorizedUsers` `decimal _balance`  |
| `SavingsAccount` (implementes Account) | `IBankTransaction _transactions` `List<IUser> authorizedUsers` `decimal _balance`  |
| `IBankTransaction` (*interface*) | |
| `TransactionManager` (implementes IBankTransaction) | `List<Tuple<DateTime, decimal>> _history` |
| `User` (*interface*) | | 
| `Customer` (*abstract*)(implements User) | `List<IAccount> accounts` `string Name` `DateTime birthDate` `DateTime lastLogin` |
| `Manager` (implements User) | `List<Customer> customers` `string Name` | 

| Classes | Method | Scenario | Outputs | 
|-|-|-|-|
| `IAccount` | `Deposit(desimal amount)` | Deposit money into the account | True |
| | | Failed to deposit money into the account | False | 
| | `Withdraw(desimal amount)` | Withdraw an amount out of the account | decimal | 
| | `PrintBankStatement(DateTime start, DateTime end)` | Generate a detailed transaction record for the account | Out/Console | 
| | `GetBalance()` | Retrieve the current balance of the account | decimal | 
| | `AddUserToAccount(IUser user)` | Add a new user to the account | true | 
| | | Failed to add new user to the account | false | 
| `GeneralAccount`  | | |
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
| | `AddDepositTransaction(decimal amount)` | Add a deposit to the transaction record | true | 
| | | Failed to add deposit to the transaction record | false | 
| | `AddWithdrawTransaction(decimal amount)` | Add a withdraw to the transaction record | true | 
| | | Failed to add withdraw to the transaction record | false | 
| `IBankTransaction` | | |  