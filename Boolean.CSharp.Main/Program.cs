// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;


// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Customer customer = new Customer();
CurrentAccount currentaccount = new CurrentAccount();
BankTransaction newtransaction = new BankTransaction();
BankTransaction secondtransaction = new BankTransaction();
BankTransaction thirdtransaction = new BankTransaction();
newtransaction.makeTransaction("23.01.2023", "Deposit", 500, currentaccount);

customer.TransactionHistory.Add(newtransaction);

secondtransaction.makeTransaction(DateTime.Now.ToString("dd/MM/yyyy"), "Deposit", 1500, currentaccount);

customer.TransactionHistory.Add(secondtransaction);

thirdtransaction.makeTransaction(DateTime.Now.ToString("dd/MM/yyyy"), "Withdrawal", 700, currentaccount);

customer.TransactionHistory.Add(thirdtransaction);

customer.generateStatement();
