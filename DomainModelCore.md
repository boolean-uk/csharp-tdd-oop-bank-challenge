| Superclass  | Subclass | members                                                           | method                                 | scenario                   | output |
|-------------|----------|-------------------------------------------------------------------|----------------------------------------|----------------------------|--------|
| Transaction | Credit   | double Amount, DateTime DateTime, double BalanceAtfterTransaction | Transaction(Amount, datetime)          | Can be only be positive    |        |
| Transaction | Debit    | double Amount, DateTime DateTime, double BalanceAtfterTransaction | Transaction(Amount, datetime)          | Can be only be positive    |        |
| User        | Client   | string Name, double Balance, List<Transaction> Transactions       | CreateUser(name)                       | name is longer than 0      |        |
|             |          |                                                                   | PrintTransactions()                    | TransactionList is printed |        |
|             |          |                                                                   | Deposit(double amount, Datetime date)  | Positive number is input   | TRUE   |
|             |          |                                                                   |                                        | Negative number is input   | FALSE  |
|             |          |                                                                   | Withdraw(Double amount, Datetime date) | Positive number is input   | TRUE   |
|             |          |                                                                   |                                        | Negative number is input   | FALSE  |
