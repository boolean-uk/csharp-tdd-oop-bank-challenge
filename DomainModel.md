| Type      | Class           | Member                                                                  | Method                  | Scenario                      | Output |
| --------- | --------------- | ----------------------------------------------------------------------- | ----------------------- | ----------------------------- | ------ |
| Enum      | TransactionType | Credit, debit                                                           |                         |                               |        |
|           | Transaction     | DateTime dt, double amount, double balance, oldBalance, TransactionType |                         |                               |        |
| Abstract  | Account         | double balance, List<Transaction>                                       |                         |                               |        |
|           |                 |                                                                         | deposit(double amount)  | Creates a transaction to List |        |
|           |                 |                                                                         | withdraw(double amount) | Creates a transaction to List |        |
| :Account  | Current         |                                                                         |                         |                               |        |
| :Account  | Savings         |                                                                         |                         |                               |        |
|           | Customer        | List<Account> account                                                   |                         |                               |        |
|           |                 |                                                                         | addAccount(Account a)   | Put Account in list           | void   |
|           |                 |                                                                         | displayTransactions()   | Order by dateTime             | void   |