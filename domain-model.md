### Bank Challenge Domain Model

#### CORE
As a customer,
So I can safely store use my money,
I want to create a current account.

As a customer,
So I can save for a rainy day,
I want to create a savings account.

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

As a customer,
So I can use my account,
I want to deposit and withdraw funds.

#### EXTENSION

As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.   ****

As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.


### Class:
* `IAccount`

#### Properties
* `private List<Transaction> transactions`
* `private string countryBranch`
* `private Guid _ID`
* `private User user`

#### Methods
* `public Account()`
  - `Account Constructor`

* `public getBalance()`
  - `return transactions(x => x.Amount).Sum()`
  
* `public getBranch()`
  - `return countryBranch`

* `public void SubmitFund(float amout)`
  - `balance.Add(amount)`
  
* `public void RequestOverdraft(Manager manager, float amout)`
  - `requests manager for overdraft. Sends user id, account id, overdraft amount and current account balance to Manager.`
  - `bool accepted = Manager.overDraftRequestResponse()`
  - `if accepted message "overdraft accepted" else send a message "not accepted!"`

* `public void WithdrawFund(float amout)`
  - `float newBalance = balance.Sum() - amount;`
  - `balance.Clear()`
  - `balance.Add(newBalance)`
  
* `public void ListBankStatements()`
  - `Console.WriteLine transaction list items`



### Class:
* `SavingsAccount : IAccount`

#### Properties
* `private List<Transaction> transactions`
* `private string countryBranch`
* `private Guid _ID`

#### Methods
* `(Same as IAccount)`



### Class:
* `GeneralAccount : IAccount`

#### Properties
* `private List<Transaction> transactions`
* `private string countryBranch`
* `private Guid _ID`

#### Methods
* `(Same as IAccount)`



### Class:
* `User`

#### Properties
* `List<IAccount> _accounts`
* `private Guid _ID`

#### Methods
* `public User()`
  - `Account Constructor`



### Class:
* `Manager`

#### Properties
* `List<User> _users`

#### Methods
* `public Manager()`
  - `Account Constructor` 

* `public bool overDraftRequestResponse(User user, Account account, float amount, float currentBalance)`
  - `if user.ID and account.ID exist, accept (true) or reject (false) the request` 






### Class:
* `Transaction`

#### Properties
* `Guid id`
* `DateTime`
* `float Amount`
* `Enum {Withdraw, Submit}`
* `float currentBalance`

#### Methods
* `public Account(DateTime dt, float Amount, Enum enum, float currentBalance)`
  - `Account Constructor`

