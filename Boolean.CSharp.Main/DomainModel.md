--USER STORIES--

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


///Domain Model

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


//Methods

public bool AddTransaction(float f) 


Float GetBalance()

String GenerateTransationsHistory() //Also Console.WriteLine





//Class SavingsAccount : Account

//Class CurrentAccount : Account


Struct Transaction

//Properties
Readonly
Datetime date, float amount