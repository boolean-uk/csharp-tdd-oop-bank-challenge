#UML Diagram Extension

|-----------------------------------|
|           BankAccount             |
|-----------------------------------|
|                                   |
| - Transactions: List<Transaction> |  
|                                   |
|-----------------------------------|
| + Deposit(amount: double): bool   |
|                                   |
| + Withdraw(amount: double): bool  |
|                                   |  
| + GenerateStatement(): string     | 
|                                   |   
| + Calculate()  double             |
|                                   |   
| - Overdraft ()  bool              |
-------------------------------------
                  |
                  |
|-----------------------------------|
|         PhoneMessage              |
|-----------------------------------|
|                                   |
|    + SendStatement()              | 
|                                   |
|                                   |
|                                   |  
-------------------------------------


|-----------------------------------|
|             Branch                |
|-----------------------------------|
|                                   |
|   - accounts: List<BankAccount>   | 
|                                   |
|                                   |  
-------------------------------------

|-----------------------------------|
|            Overdraft              |
|-----------------------------------|
|                                   |
|   - requesting: BankAccount       | 
|   + Approve(): bool               |
|   + Reject(): bool                |
|                                   |  
-------------------------------------
