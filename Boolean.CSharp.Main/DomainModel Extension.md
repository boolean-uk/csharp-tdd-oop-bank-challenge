--USER STORIES-- CORE

As a customer,
So I can safely store use my money,
I want to create a current account.

As a customer,
So I can save for a rainy day,
I want to create a savings account.

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

As a customer,
So I can use my account,
I want to deposit and withdraw funds.

Given a client makes a deposit of 1000 on 10-01-2012
And a deposit of 2000 on 13-01-2012
And a withdrawal of 500 on 14-01-2012
When she prints her bank statement
Then she would see:

date       || credit  || debit  || balance
14/01/2012 ||         || 500.00 || 2500.00
13/01/2012 || 2000.00 ||        || 3000.00
10/01/2012 || 1000.00 ||        || 1000.00



--USER STORIES --
EXTENSION

done As an engineer,
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

--- 

///Domain Model

Class Bank

//Properties
Dict<int id, string Location> branches

Methods 
GetBranches()
CheckIfBranchExists(int id OR String Location)



//Interface IAccount
//Methods

        public List<Transaction> GetTransactions();
        public bool AddTransaction(float f);
        public float GetBalance();
        String GenerateTransactionHistory();
    }

//Class Account :IAccount

//properties
private List<Transactions> transactions

Public List<Transactions> transactions readonly

private Transaction OverdraftRequest

int id branch


//Methods

Account(Bank bank, string branch)

bool UpdateBranch(String branch)
            - Check if branch exists in bank and update
            - otherwise false

public bool AddTransaction(float f,optional DateTime?) 
            -true if no overdraft
            -false if overdraft

public bool RequestOverdraft(float amount) 
            - true if request is submitted
            - return false if another overdraft is alrdy pending

Float GetBalance()

String GenerateTransationsHistory() //Also Console.WriteLine





//Class SavingsAccount : Account

//Class CurrentAccount : Account


Struct Transaction

//Properties
Readonly
Datetime date, float amount