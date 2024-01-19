Class: Account

Properties: Id (int), Balance (float), Transactions (List<Transaction>)
Methods:
Deposit(float amount): Adds an amount to the account. Returns true if the deposit was successful, false otherwise.
Withdraw(float amount): Removes an amount from the account. Returns true if the withdrawal was successful, false otherwise.
ViewBalance(): Returns the balance of the account as a float.

Class: CurrentAccount
CurrentAccount class inherits from the Account class, which means it has all the properties and methods defined in the Account class.
Inherits from: Account

Class: SavingsAccount
Same thing as Current Account
Inherits from: Account

Class: Transaction

Properties: Date (DateTime), Credit (float), Debit (float), BalanceAfterTransaction (float)

Class: BankStatement

Properties: Transactions (List<Transaction>)
Methods:
PrintStatement(): Prints the bank statement. Does not return a value.

Class: Customer

Properties: Accounts (List<Account>)
Methods:
CreateCurrentAccount(): Creates a new current account. Returns the created CurrentAccount object.
CreateSavingsAccount(): Creates a new savings account. Returns the created SavingsAccount object.
GenerateBankStatement(int accountId): Generates a bank statement for the account with the given id. Returns the generated BankStatement object.