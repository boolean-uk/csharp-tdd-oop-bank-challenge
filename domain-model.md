User Stories

1. As a customer,\
So I can safely store use my money,\
I want to create a current account.

2. As a customer,\
So I can save for a rainy day,\
I want to create a savings account.

3. As a customer,\
So I can keep a record of my finances,\
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

4. As a customer,\
So I can use my account,\
I want to deposit and withdraw funds.


| Classes                   | Methods                                    | Scenario                                       | Outputs                        |
|---------------------------|--------------------------------------------|------------------------------------------------|--------------------------------|
| Customer                  | List\<IAccount> accounts {get; set;}        | Store a customers accounts                     | List\<IAccount> accounts        |
|                           | CreateAccount(AccountType accountType)     | Customer can open an account of their choice   | bool                           |
| enum AccountType          |                                            | store types of accounts as values              | Current, Savings               |
| IAccount                  | decimal Balance {get; set;}                | Store account balances                         | decimal balance                |
|                           | private readonly int Id                            | store unique accountId                         | int Id                         |
|                           | private readonly AccountType type              | store type of account                          | AccountType type             |
|                           | List\<Transaction> transactions {get; set;} | store all account transactions                 | List\<Transaction> transactions |
|                           | Deposit(decimal amount)                    | Deposit money into an account                  | bool                           |
|                           | Withdraw(decimal amount)                   | Withdraw money from an account                 | bool                           |
|                           | GenerateStatement()                        | generate/print statement from selected account | void                           |
| CurrentAccount : IAccount | -> IAccount                                |                                                |                                |
| SavingsAccount : IAccount | -> IAccount                                |                                                |                                |
| Transaction               | Date date {get; set;}                      | store transaction date                         | Date date                      |
|                           | decimal Amount {get; set;}                 | store transaction amount                       | decimal amount                 |
|                           | decimal Balance {get; set;}                | store updated balance at time of transaction   | decimal balance                |