# Domain Model - Bank Challenge

| Class/Interface   | Members                      | Method/Property             | Scenario                     | Output     |
|-------------------|------------------------------|-----------------------------|------------------------------|------------|
| BankAccount       | `decimal balance`            | Deposit(decimal amount)     | deposit amount to account    | bool       |
|                   | `List<BankStatement>`        | Withdraw(decimal amount)    | withdraw amount from account | bool       |
|                   | `BankBranch bankBranch`      | Balance {get;}              | get the balance of account   | decimal    |
|                   |                              | BankStatements {get;}       | get the bank statements      | List<BankStatement>|
|                   |                              | BankBranch {get;}           | get the branch of the account| BankBranch |
|                   |                              |                             |                              |            |
| CurrentAccount    | inherits from BankAccount    |                             |                              |            |
|                   |                              |                             |                              |            |
| SavingsAccount    | inherits from BankAccount    |                             |                              |            |
|                   |                              |                             |                              |            |
| BankStatement     | `DateTime dateTime`          | DateTime {get;}             | date & time of transaction   | DateTime   |
|                   | `decimal amount`             | Amount {get;}               | transaction amount           | decimal    |
|                   | `string type`                | Type {get;}                 | credit or debit transaction  | string     |
|                   | `decimal balance`            | Balance {get;}              | total balance after transact | decimal    |
|                   |                              |                             |                              |            |
| BankBranch        | `string name`                | Name {get;}                 | name of the bank             | string     |
|                   | `string location`            | Location {get;}             | location of the bank branch  | string     |
|                   |                              |                             |                              |            |
| Person            | `string name`                | Name {get;}                 | name of the person           | string     |
|                   | `int id`                     | Id {get;}                   | id of the person             | int        |
|                   |                              |                             |                              |            |
| Customer          | inherits from Person         |                             |                              |            |
|                   |                              |                             |                              |            |
| Manager           | inherits from Person         |                             |                              |            |
|                   |                              |                             |                              |            |
| ISMSSender        |                              | SendSMS(string msg, string phoneNr)| send SMS with msg to phone| void   |
|                   |                              |                             |                              |            |
| TwilioSMS         |                              | implements from ISMSSender  |                              |            |