# Domain model for TDD Bank challenge

| Classes | Fields | 
|-|-|
| `IAccount` (*interface*) | `TransactionManager _transactions` `List<User> authorizedUsers` `decimal _balance` |
| `PersonalAccount` (implementes IAccount)| `IBankTransaction _transactions` `List<IUser> authorizedUsers` `decimal _balance` `decimal _overdrawLimit` |
| `GeneralAccount` (implementes PersonalAccount) | |
| `SavingsAccount` (implementes PersonalAccount) | |
| `IBankTransaction` (*interface*) | |
| `TransactionManager` (implementes IBankTransaction) | `List<Tuple<DateTime, decimal, TransactionType, decimal>> _history` |
| `IUser` (*interface*) | | 
| `Customer` (*abstract*)(implements IUser) | `List<IAccount> accounts` `string Name` `DateTime birthDate` `DateTime lastLogin` `IBankBranch _branch`|
| `Manager` (implements IUser) | `List<Customer> customers` `string Name` `IBankBranch _branch` `List<IOverdraftRequest> _overdraftRequests` | 
| `IBankBranch` (*interface*) |  |
| `LocalBank`  (implements IBankBranch) | `List<IAccount> _accounts` `List<Customer> _customers` `List<IUser> _employees` `string _location` |
| `IOverdraftRequest` (*interface*) | | 
| `OverdraftRequestFixedAmount` (implements IOverdraftRequest) | `Customer _customer` `decimal _desiredOverdraftLimit` `DateTime time` `IAccount _account` | 

| Classes | Method | Scenario | Outputs | 
|-|-|-|-|
| `IAccount` | `Deposit(desimal amount)` | Deposit money into the account | True |
| | | Failed to deposit money into the account | False | 
| | `Withdraw(desimal amount)` | Withdraw an amount out of the account | decimal | 
| | `PrintBankStatement(DateTime start, DateTime end)` | Generate a detailed transaction record for the account | Out/Console | 
| | `GetBalance()` | Retrieve the current balance of the account | decimal | 
| | `AddUserToAccount(IUser user)` | Add a new user to the account | true | 
| | | Failed to add new user to the account | false | 
| | `setOverdrawLimit(decimal limit, IUser user)` | Attempt to change overdraw limit, only allowed for managers | decimal |
| `PersonalAccount` | `GetTransactionManager()` | Retrieve the PersonalAccount transaction manager | IBankTransaction | 
| `GeneralAccount`  | | |
| `SavingsAccount` | | |
| `IUser` | `GetName()` | Retrieve the name of the user | string |
| | `GetAccounts()` | Retrieve a list of all accounts associated with the user | List<Account> |
| | `AddAccountToUser(IAccount account)` | Add the account to the user object | true |
| | | Failed to add the account to the user | false | 
| `Customer` | `GetAge()` | Retrieve the customers age | int | 
| | `OpenNewAccount(AccountType accountType)` | Generate a new account associated with the user | True |
| | | Failed to generate a new account | False | 
| | `LogIn()` | Log the customer into their account | - |
| | `RequestOverdraft(Customer customer, decimal amount, IAccount account)` | Send a request to the bank branch to set their overdraft limit to the provided value | void |
| `IEmployee` | `EvaluateOverdraftRequests(bool approved)` | Review the oldest overdraft request associated with the manager | void | 
| | `ShowOldestOverdraftRequest()` | Retrieve the oldest overdraft request so the manager can review | string | 
| | `AddOverdraftRequest()` | Add an overdraft request to the employees list of requests | void | 
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
| | `AssignOverdraftRequest(IOverdraftRequest request)` | Assign a overdraft request from a customer to one of the branch's employees | void | 
| `LocalBank()` | | |
| `IOverdraftRequest` | `GetRequester()` | Retrieve the Customer object that requested the overdraft | Customer | 
| | `GetRequestOverdraftLimit()` | Retrieve the requested new overdraft limit | decimal | 
| | `GetRequestDate()` | Retrieve the date that the overdraft request was made | DateTime | 
| | `GetOverdraftRequestAccount()` | Retrieve the account that the customer wish to be able to overdraft on | IAccount |
| `OverdraftRequestFixedAmount` | | | 

## Note on overdraft request approval
In my model the overdraft request is made from the user (Customer object) to the assocaited branch. The branch then have some distribution among its own managers, that it then redirects the overdraft request to. 

Each manager gets a queue of overdraft requests, which they can review and approve/disapprove which then sets the overdraft value in the Customer object associated. 

The branch distribution of overdraft requests in this implementation will be simple (just picking one) but could easily be expanded to have all managers report their queues, then select the one with the smallest queue or something like that.

### IOverdraftRequest
The interface for overdraft request is made to have a common implementation, in theory someone could when implement fancier overdraft models instead of a fixed amount like % of income, % of assets, % increase of current fixed asset etc.
