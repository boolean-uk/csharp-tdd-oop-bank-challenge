Class Account
 private float money;
 private Logger logger;
 bool Deposit(float money)
 bool Withdraw(float money)

Class SavingsAccount : Account


Class Logger 
 private List<string> log;
 string AddLog(float change, float balance)
 void Print()