# Domain Model

| Classes    | Methods/Properties     | Scenario                                          | Outputs                            |
|------------|------------------------|---------------------------------------------------|------------------------------------|
| User.cs    | CreateCurrentAccount() | Creating a new current account                    |                                    |
| User.cs    | CreatesavingsAccount() | Creating a new savings account                    |                                    |
| Account.cs | PrintBankStatement()   | Want to see their bank statement                  | Their bank statement               |
| Account.cs | Deposit(), Withdraw()  | Want to deposit/withdraw from thier account       |                                    |
| Account.cs | GetBalance()           | Engineer want balance calculated by trans history | Balance or Sum of credit and debit |
| User.cs    | RequestOverdraft()     | A customer wants to overdraft their account       |                                    |
| User.cs    | HandleOverdraft()      | A manager need to approve of reject the request   | true/false                         |