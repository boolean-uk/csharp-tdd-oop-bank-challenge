1.
As a customer,
So I can safely store use my money,
I want to create a current account.
| Classes  | Methods    | Scenario                              | Outputs    |
|----------|------------|---------------------------------------|------------|
|`Current` | `Current`  | create current account to store money | Void       |

2.
As a customer,
So I can save for a rainy day,
I want to create a savings account.
| Classes | Methods  | Scenario                              | Outputs  |
|---------|----------|---------------------------------------|----------|
|`Saving` | `Saving` | create savings account to save money  | Void     |

3.
As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
| Classes  | Methods          | Scenario                                                                                     | Outputs          |
|----------|------------------|----------------------------------------------------------------------------------------------|------------------|
|`Bank`    | `WriteStatement` | generate bank statements with transaction dates, amounts, and balance at time of transaction | Void             |

4.
As a customer,
So I can use my account,
I want to deposit and withdraw funds.
| Classes | Methods           | Scenario         | Outputs |
|---------|-------------------|------------------|---------|
|`Bank`   | `Deposit`         | deposit funds    | Int     |
|         | `Withdraw`        | withdraw funds   | Int     |