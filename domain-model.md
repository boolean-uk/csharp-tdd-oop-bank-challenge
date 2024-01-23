Domain model include both core and extension

|class                      | Method                                                                                                           | output | 
|---------------------------|------------------------------------------------------------------------------------------------------------------|--------|
|Customer                   |                                                                                                                  |        |
|CurrentAccount             |                                                                                                                  |        |
|SavingsAccount             |                                                                                                                  |        |
|                           | `Deposit(Guid guid, double amount, Customer customer), Withdraw(Guid guid, double amount, Customer customer)`    |        |
|Bank 			            | `GenerateBankStatement()`																					   |        |
|                           | `TransactionStatement()`																						   |        |
|                           | `GetBalance()`																								   |        |
|                           | `RequestOverdraft(Customer customer, Guid guid, double amount)`												   |        |
|                           | `AcceptOverdraft(Customer customer, Guid guid)`																   |        |
|                           | `RejectOverdraft(Customer customer, Guid guid)`																   |        |