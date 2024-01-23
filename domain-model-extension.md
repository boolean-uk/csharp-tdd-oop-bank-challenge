```
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.
```

#Bank account is mostly the same as on core

| Classes            | Members                                   | Methods                                                           | Scenario                     | Outputs |
|--------------------|-------------------------------------------|-------------------------------------------------------------------|------------------------------|---------|
| `Extension`        | Bank _bank                                | `createBank(string name, string regNr, Manager manager)`          |                              |         |
| `Bank`             | List<BankBranch> _banks                   | `createBankBranch(string branchName)`                             | name is not empty and unique | true    |
|                    |                                           |                                                                   | name is empty or exists      | false   |
| `BankBranch`       | List<Customer> _customers                 | `createCustomer(string name, string customerNr)`                  | Nr is unique                 | true    |
|                    |                                           |                                                                   | Nr is not unique             | false   |
| `Customer`         | List<BankAccount> _accounts               | `createCurrentAccount(string controllNr)`                         | nr is unique                 | true    |
|                    |                                           |                                                                   | nr is not unique             | false   |
|                    | List<BankAccount> _accounts               | `createSavingsAccount(string controllNr)`                         | nr is unique                 | true    |
|                    |                                           |                                                                   | nr is not unique             | false   |
|                    |                                           | `createOverdraftRequest(int id, string accountNr, double amount)` |                              |         |
| `OverdraftRequest` | string _status                            | `grantRequest()`                                                  |                              |         |
|                    | string _status                            | `denyRequest()`                                                   |                              |         |
| `Manager`          | List<OverdraftRequest> _overdraftRequests | `addOverdraftRequest(OverdraftRequest request)`                   |                              |         |
| `IMessage`         |                                           | `SendMessage(string message)`                                     |                              |         |