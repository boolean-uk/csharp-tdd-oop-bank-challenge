| Classes     | Methods                          | Scenario                                  | Outputs |
|-------------|----------------------------------|-------------------------------------------|---------|
| `Account`   | `Deposit(double amount)`         | Deposits into account                     | void    |
|             | `Withdraw(double amount)`        | Withdraws from account                    | bool    |
|             | `BankStatement()`                | Returns a bank statement                  | string  |
|             | `GetBalance()`                   | Calculates the balance based on acitivity | double  |
|             | `new Account(Branch brach)`      | Associates an account with a branch       | void    |
|             | `RequestOverdraft(Overdraft od)` | Requests an overdraft on the account      | void    |
| `Overdraft` | `Approve()`                      | Approves the overdraft request            | void    |
|             | `Reject()`                       | Rejects the overdraft request             | void    |