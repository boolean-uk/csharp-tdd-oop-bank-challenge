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

_______


### Class
* interface IAccount

#### Methods
* public AccountType ACCTYPE { get; }
* public string BRANCH { get; }
* public string ID { get; }
* public float getBalance();
* public bool MakeTransaction();
* public void ListBankStatement();

_______

### Class
* abstract Account : IAccount

#### Properties
* private string _ID;
* private AccountType _type;
* private string _branch;
* private List<Transaction> _transactions = new List<Transaction>();

#### Methods
* public Account(AccountType type, string branch)
  - Account Constructor

* public void acceptOverdraft(float amount, TransactionType type)
  - processes the accepted overdraft
  
* public static Account createAccount(AccountType type, string branch)
  - creates a new account.

* public float getBalance()
  - calculates the current balance from the _transactions list
  
* public bool MakeTransaction(float amount, TransactionType type)
  - adds a new transaction to the _transactions list. Type can be either DEPOSIT or WITHDRAW.

* public bool MakeTransaction(float amount, TransactionType type, string date)
  - adds a new transaction to the _transactions list. Type can be either DEPOSIT or WITHDRAW. Date of the transaction is specified separately.


* public void ListBankStatement()
  - prints the _transactions list in the desired format
  
_______

### Class:
* SavingsAccount : Account

#### Methods
* public SavingsAccount(AccountType type, string branch) : base(type, branch)
  - Constructor

_______

### Class:
* GeneralAccount : Account

#### Methods
* public SavingsAccount(AccountType type, string branch) : base(type, branch)
  - Constructor

_______



### Class:
* Customer

#### Properties
* List<IAccount> _accounts
* private Guid _ID

#### Methods
* public Customer()
  - Customer Constructor

* public IAccount addAccount(AccountType type, string branch)
  - creates new account and adds it to the _accounts list
  - returns the account

* public bool requestOvedraft(string accountID, float amount)
  - requests overdraft from manager.
  - makes sure that the account exists and is a GeneralAccount
  - if request accepted, the account calls the acceptOverdraft method
  - returns true if overdraft was successful, false otherwise

* public List<IAccount> ListAccounts()
  - returns the _accounts list

_______


### Class:
* Manager

#### Properties
* private static List<Customer> _users= new List<Customer>();
* public static List<Customer> Users { get { return _users;  } }

#### Methods
* public Manager()
  - Constructor
   
* public void registerCustomer(Customer user)
  - adds customer to the _users list

* public static bool handleOverdraftRequest(string ID, GeneralAccount account, float amount)
  - console.writelines the customer id, the requested withdraw amount and the accounts balance
  - Accepts user input (console.readline) for a Y/N answer
  - return true if input is Y, false otherwise

_______


### Class:
* Transaction

#### Properties
* private string _ID;
* private DateTime _dateTime;
* private TransactionType _type;
* private float _amount;
* private float _currentBalance;

#### Methods
* public TransactionType TransactionType { get { return _type; } }
  
* public float Amount { get { return _amount; } }
  
* public DateTime DateTime { get { return _dateTime; } }
  
* public float Balance { get { return _currentBalance; } }


* public Transaction(float amount, TransactionType type, float balance)
  - constructor, date DateTime.Now

* public Transaction(string date, float amount, TransactionType type, float balance)
 - constructor, date specified

_______