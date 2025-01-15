## Domain-model Bank Challenge

### 1
| functions       | variables      | Scenario              | Output |
|-----------------|----------------|-----------------------|--------|
| createAccount() | int storeMoney | if create account     | true   |
|                 |                | if not create account | false  |
|                 |                |                       |        |

### 2

| functions              | variables      | Scenario              | Output |
|------------------------|----------------|-----------------------|--------|
| createSavingsAccount() | int storeMoney | if create account     | true   |
|                        |                | if not create account | false  |
|                        |                |                       |        |

### 3

| functions               | variables                       | Scenario                 | Output |
|-------------------------|---------------------------------|--------------------------|--------|
| saveTransaction(amount) | double amount                   | if transaction saved     | true   |
|                         | double balance                  | if transaction not saved | false  |
|                         | date transactionDate            |                          |        |
|                         | Hashmap<Integer, transaction[]> |                          |        |
|                         | String[] transaction            |                          |        |

### 4

| functions  | variables      | Scenario               | Output |
|------------|----------------|------------------------|--------|
| deposit()  | int storeMoney | if money saved account | true   |
| withdraw() | int takeMoney  | if not saved account   | false  |
|            |                | if withdraw success    | true   |
|            |                | if withdraw not success| false  |
