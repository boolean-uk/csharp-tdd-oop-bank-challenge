***
# User stories for Bank challenge

#### 1. As a customer, <br> So I can safely store use my money, <br> I want to create a current account.

#### 2. As a customer, <br> So I can save for a rainy day, <br> I want to create a savings account.

#### 3. As a customer, <br> So I can keep a record of my finances, <br> I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

#### 4. As a customer, <br> So I can use my account, <br> I want to deposit and withdraw funds.

***

### Bank domain models

| **Classes** | **Methods** | **Scenario** | **Outputs** | **Description** |
|:---:|:---:|:---:|:---:|
| `Customer` | CreateAccount() | Create an account for normal use | bool | The CreateAccount()-method calls a method in  |
|  | CreateSavingsAccount() | Create a savings account | bool | The CreateSavingsAccount()-method creates an account by calling a method in the Bank-class. Send customer ID? The customer ID then becomes a key for a dictionary in Bank. |
|  | GetBankStatement() | Generate a bank statement  | void | The GetBankStatement()-method does a print that contains transaction dates, amounts and the balance at the time of the transaction. |
| `IBankAccount` | Withdraw(decimal) | Withdraw money from an account | bool | The Withdraw()-method makes a Transaction-object sends it to an account.
|  | Deposit(decimal) | Deposit money to an account | bool | The Deposit()-method makes a Transaction-object and sends it to an account money from an account.

***

### Overview of Classes

| **Classes** | Properties |
|:---:|:---:|
|`Bank`| Dictionary\<int, IBankAccount> _bankAccounts_|
|`Person`| Bank _bank_, int _id_, string _name_ |
|`Manager : Person`|  |
|`Customer : Person`| List\<IBankAccount> _bankAccounts_ |
|`Engineer : Person`|  |
|`IBankAccount`| string _accountName_, bool _savingsAccount_, List\<Transaction> _transactionHistory_ |
|`SavingsAccount : IBankAccount`|  |
|`Account : IBankAccount`|  | 
|`Transaction`| DateTime _date_, string _typeOfTransaction_, decimal _amount_ |
|`TransactionType`| enum _Current_, enum _Saving_ |
|`AccountType`| enum _Withdraw_, enum _Deposit_ |
