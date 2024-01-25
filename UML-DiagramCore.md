#UML Diagram Core

CurrentAccount Class Diagram

|-----------------------------------|
|           CurrentAccount          |
|-----------------------------------|
|                                   |
|   Transactions: List<Transaction> |  
|                                   |
|-----------------------------------|
| + Deposit(amount: double): bool   |
|                                   |
| + Withdraw(amount: double): bool  |
|                                   |  
| + GenerateStatement(): string     | 
|                                   |   
|                                   |
-------------------------------------

SavingsAccount Class Diagram


|-----------------------------------|
|          SavingsAccount           |
|-----------------------------------|
|                                   |
|   Transactions: List<Transaction> |  
|                                   |
|-----------------------------------|
| + Deposit(amount: double): bool   |
|                                   |
| + Withdraw(amount: double): bool  |
|                                   |  
| + GenerateStatement(): string     | 
|                                   |   
|                                   |
-------------------------------------


BankAccount Class Diagram

|-----------------------------------|
|           BankAccount             |
|-----------------------------------|
|                                   |
|   Transactions: List<Transaction> |  
|                                   |
|-----------------------------------|
| + Deposit(amount: double): bool   |
|                                   |
| + Withdraw(amount: double): bool  |
|                                   |  
| + GetBalance(): double            | 
|                                   |   
| + GenerateStatement(): void       |
-------------------------------------

Transaction Class Diagram

|-----------------------------------|
|          Transaction              |
|-----------------------------------|
|    Date: DateTime                 |
|    Amount: double                 |
|    Type: string                   |
|    Balance: double                |
|-----------------------------------|
| + GetTransactionDate(): DateTime  |
|                                   |
| + GetTransactionAmount(): double  |
|                                   |  
| + GetTransactionBalance(): double | 
|                                   |   
|                                   |
-------------------------------------

ITransactionable Interface Diagram

|-----------------------------------|
|        ITransactionable           |
|-----------------------------------|
|                                   |
| + Deposit(amount: double): bool   |
| + Withdraw(amount: double): bool  |
| + GenerateStatement(): void       |
|                                   |
|               ...                 |
-------------------------------------

TransactionType Enum Diagram


|-----------------------------------|
|        TransactionType            |
|-----------------------------------|
|                                   |
| + Deposit                         |
| + Withdraw                        |
|                                   |
|               ...                 |
-------------------------------------
