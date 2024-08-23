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

Extension

5.  As an engineer,\
So I don't need to keep track of state,\
I want account balances to be calculated based on transaction history instead of stored in memory.

6. As a bank manager, \
So I can expand, \
I want accounts to be associated with specific branches.

7. As a customer,\
So I have an emergency fund,\
I want to be able to request an overdraft on my account.

8. As a bank manager,\
So I can safeguard our funds,\
I want to approve or reject overdraft requests.

9.  As a customer,\
So I can stay up to date,\
I want statements to be sent as messages to my phone.

| Classes                   | Methods                                    | Scenario                                       | Outputs                        |
|---------------------------|--------------------------------------------|------------------------------------------------|--------------------------------|
| BankManager               | ApproveOverdraft(IAccount account, decimal amountApproved) | Approve a customers overdraft  | bool    |
| BankManager               | RejectOverdraft(IAccount account)          | Reject a customers overdraft request           | bool    |
| Customer                  | List\<IAccount> accounts {get; set;}        | Store a customers accounts                     | List\<IAccount> accounts      |
|                           | CreateAccount(AccountType type, Branch branch)            | Customer can open an account of their choice   | bool            |
|                           | RequestOverdraft(IAccount account)         | Customer can request an arranged overdraft     | void                           |
| enum AccountType          |                                            | store types of accounts as values              | Current, Savings               |
| IAccount                  | decimal GetBalance()                       | Calculate bal based on transactions            | decimal balance                |
|                           | AccountType Type {get;}                    | Store account type                             | AccountType type               |
|                           | bool OverdraftRequestIsActive { get; set; }| see whether a request is active                | bool                           |
|                           | public decimal BalanceLimit { get; set; }  | Store bal limit given in overdraft             | decimal balanceLimit           |
|                           | Branch Branch {get;}                       | Store branch                                   | Branch branch                  |
|                           | List\<Transaction> Transactions {get; set;}| store all account transactions                 | List\<Transaction> transactions |
|                           | Deposit(decimal amount)                    | Deposit money into an account                  | bool                           |
|                           | Withdraw(decimal amount)                   | Withdraw money from an account                 | bool                           |
|                           | GenerateStatement()                        | generate/print statement from selected account | void                           |
|                           | TextBankStatement()                        | text bank statement to phone                   | void                           |
| CurrentAccount : IAccount | -> IAccount                                |                                                |                                |
| SavingsAccount : IAccount | -> IAccount                                |                                                |                                |
| enum TransactionType      |                                            | store types of transactions                    | Deposit, Withdraw              |
| enum Branch               |                                            | store branches                                 | Oslo, Southampton, Bournemouth, Stockholm, etc  |
| Transaction               | DateTime _Date {get;}                      | store transaction date                         | Date date                      |
|                           | TransactionType Type {get; }               | store transaction type                         | TransactionType type           |
|                           | string FormattedDate                       | store date as string                           | string date                    |
|                           | decimal Amount {get; }                     | store transaction amount                       | decimal amount                 |
|                           | decimal RemainingBalance { get; }          | store remaining balance | decimal remainingBalance                |