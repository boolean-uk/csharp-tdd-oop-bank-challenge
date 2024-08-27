#Domain Models




| Classes              | Methods                                         | Scenario                                                            | Outputs                                                                                                           |
|----------------------|-------------------------------------------------|---------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------|
| `Customer`           | `CreateAccount(string name)`                    | A customer creates a new account                                    | new account object is created that belongs to the customer                                                        |
| 	              	   | `getaccounts()`                                 | A customer with a transactionhistory generates statment.            | Returns statments containing history with transaction dates, amounts, and balance at the time of transaction      |
|                      |                                                 |                                                                     |                                                                                                                   |
|`IAccount`		       | `DepositFunds(double funds)`                    | A value of 100 is added to the account                              | the account value is uppdated to reflect this change                                                              |
|    			       | `WithdrawFunds(double funds)`                   | A value of 100 is withdrawn fom an acocuntwith less than 100 in it. | A request is sent to the manager to ask for permission                                                            |
|   			       | `GenerateBankStatment()`                        | GenerateBankstatmet is called for specified account and customer    | Returns a bankstatment                                                                                            |
|   			       | `GetAccountName()`                              | Function is called for a specific   account                         | Returns name of account                                                                                           |
|   			       | `GetBalance();`                                 | Function is called for a specific   account                         | Returns corrent balance based on history                                                                          |
|        		       | `SetBranch(string branch)`                      | Function is called to set accoung to specific branch                | Account is set to specific branch                                                                                 |
|                      |                                                 |                                                                     |                                                                                                                   | 
| `SavingsAccount`	   | `Note: implements IAccount`                     |                                                                     |                                                                                                                   |
|                      |                                                 |                                                                     |                                                                                                                   |
| `Management`		   | `AddCustomer(Cuustomer)`                        | Add cusomer to list when customer is created                        | Cusomer is added to list of customers                                                                             |
|    			       | `GetCustomers()`                                | Function is called                                                  | Returns list of current customers                                                                                 |
