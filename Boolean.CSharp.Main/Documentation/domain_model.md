# Domain model for TDD Bank challenge

| Classes | Fields | 
|-|-|
| `IAccount` (*interface*) | `TransactionManager _transactions` `List<User> authorizedUsers` `decimal _balance` |
| `GeneralAccount` (implementes IAccount) | `IBankTransaction _transactions` `List<IUser> authorizedUsers` `decimal _balance` `decimal _overdrawLimit` |
| `SavingsAccount` (implementes IAccount) | `IBankTransaction _transactions` `List<IUser> authorizedUsers` `decimal _balance`  |
| `IBankTransaction` (*interface*) | |
| `TransactionManager` (implementes IBankTransaction) | `List<Tuple<DateTime, decimal, TransactionType, decimal>> _history` |
| `IUser` (*interface*) | | 
| `Customer` (*abstract*)(implements IUser) | `List<IAccount> accounts` `string Name` `DateTime birthDate` `DateTime lastLogin` `IBankBranch _branch`|
| `Manager` (implements IUser) | `List<Customer> customers` `string Name` `IBankBranch _branch` | 
| `IBankBranch` (*interface*) |  |
| `LocalBank`  (implements IBankBranch) | `List<IAccount> _accounts` `List<Customer> _customers` `List<IUser> _employees` `string _location` |

| Classes | Method | Scenario | Outputs | 
|-|-|-|-|
| `IAccount` | `Deposit(desimal amount)` | Deposit money into the account | True |
| | | Failed to deposit money into the account | False | 
| | `Withdraw(desimal amount)` | Withdraw an amount out of the account | decimal | 
| | `PrintBankStatement(DateTime start, DateTime end)` | Generate a detailed transaction record for the account | Out/Console | 
| | `GetBalance()` | Retrieve the current balance of the account | decimal | 
| | `AddUserToAccount(IUser user)` | Add a new user to the account | true | 
| | | Failed to add new user to the account | false | 
| `GeneralAccount`  | `setOverdrawLimit(decimal limit, IUser user)` | Attempt to change overdraw limit, only allowed for managers | decimal |
| `SavingsAccount` | | |
| `IUser` | `GetName()` | Retrieve the name of the user | string |
| | `GetAccounts()` | Retrieve a list of all accounts associated with the user | List<Account> |
| | `AddAccountToUser(IAccount account)` | Add the account to the user object | true |
| | | Failed to add the account to the user | false | 
| `Customer` | `GetAge()` | Retrieve the customers age | int | 
| | `OpenNewAccount(AccountType accountType)` | Generate a new account associated with the user | True |
| | | Failed to generate a new account | False | 
| | `LogIn()` | Log the customer into their account | - |
| `Manager`  | `GetCustomers()` | Retrieve a list of customers associated with this manager | List<Customer> | 
| `IBankTransaction` (*interface*)| | |  
|  | `PrintTransactions(DateTime start, DateTime end)` | Print the transaction record between the provided DateTimes | Out/Console | 
| | `AddDepositTransaction(decimal amount)` | Add a deposit to the transaction record | true | 
| | | Failed to add deposit to the transaction record | false | 
| | `AddWithdrawTransaction(decimal amount)` | Add a withdraw to the transaction record | true | 
| | | Failed to add withdraw to the transaction record | false | 
| | `CalculateAccountBalance()` | Calculate a monetary balance based on the entire history of the account | decimal | 
| `TransactionManager` | | |
| `IBankBranch` (*interface*) | `GetLocation()` | Retrieve the location of the branch | string | 
| | `GetAccounts()` | Retrieve a list of accounts associated with the branch | List<IAccount> |
| | `GetCustomers()` | Retrieve a list of Customers associated with the branch | List<Customer> |
| | `GetEmployees()` | Retrieve a list of employees associated with the branch | List<IUser> | 
| | `AddAccountToBranch(IAccount account)` | Associate the provided account with the branch | bool |
| | `AddUserToBranch(Customer user)` | Associate the provided Customer with the branch | bool | 
| | `AddEmployeeToBranch(IUser employee)` | Associate the provided employee with the branch | bool |
| `LocalBank()` | | |