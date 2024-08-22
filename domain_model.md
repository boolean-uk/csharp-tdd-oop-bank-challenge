# Domain Model - Bank Challenge

For this basic example, using an abstract class for the bank account might seem like a better idea, due to the implementation
being almost identical based on the user stories for a current account, and a savings account. But in a realistic implementation
we might want Deposit and Withdraw to behave differently depending on the account, which makes an interface seem like a logical choice.
This also holds true if we wanted to implement interest rates for an account as well, as doing so would depend on what type
of account it is.

| Class/Interface   | Members                      | Method/Property             | Scenario                     | Output     |
|-------------------|------------------------------|-----------------------------|------------------------------|------------|
| IBankAccount      |                              | Deposit(decimal amount)     | deposit amount to account    | bool       |
|                   |                              | Withdraw(decimal amount)    | withdraw amount to account   | bool       |
|                   |                              | Balance {get;}              | get the balance of account   | decimal    |
|                   |                              | BankStatements {get;}       | get the bank statements      | List<BankStatement>|
|                   |                              | BankBranch {get;}           | get the branch of the account| BankBranch |
|                   |                              |                             |                              |            |
| CurrentAccount    | `decimal balance`            | implements from IBankAccount|                              |            |
|                   | `List<BankStatement>`        |                             |                              |            |
|                   | `BankBranch bankBranch`      |                             |                              |            |
|                   |                              |                             |                              |            |
| SavingsAccount    | `decimal balance`            | implements from IBankAccount|                              |            |
|                   | `List<BankStatement>`        |                             |                              |            |
|                   | `BankBranch bankBranch`      |                             |                              |            |
|                   |                              |                             |                              |            |
| BankStatement     | `DateTime dateTime`          | DateTime {get;}             | date & time of transaction   | DateTime   |            |
|                   | `decimal amount`             | Amount {get;}               | transaction amount           | decimal    |
|                   | `string type`                | Type {get;}                 | credit or debit transaction  | string     |
|                   | `decimal balance`            | Balance {get;}              | total balance after transact | decimal    |
|                   |                              |                             |                              |            |
| BankBranch        | `string name`                | Name {get;}                 | name of the bank             | string     |
|                   | `string location`            | Location {get;}             | location of the bank branch  | string     |
|                   |                              |                             |                              |            |
| IPerson           |                              | Name {get;}                 | name of the person           | string     |
|                   |                              | Id {get;}                   | id of the person             | int        |
|                   |                              |                             |                              |            |
| Customer          | `string name`                | implements from IPerson     |                              |            |
|                   | `int id`                     |                             |                              |            |
|                   |                              |                             |                              |            |
| Manager           | `string name`                | implements from IPerson     |                              |            |
|                   | `int id`                     |                             |                              |            |
|                   |                              |                             |                              |            |
| ISMSSender        |                              | SendSMS(string msg, string phoneNr)| send SMS with msg to phone| void   |
|                   |                              |                             |                              |            |
| TwilioSMS         |                              | implements from ISMSSender  |                              |            |