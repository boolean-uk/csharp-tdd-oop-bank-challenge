// See https://aka.ms/new-console-template for more information

using Boolean.CSharp.Main;

User user = new User(0, "Kristian", "Test@email.com", "password");

user.Deposit(1000, user.Account);
user.Deposit(2000, user.Account);
user.Withdraw(500, user.Account);

user.GenerateBankStatement(user.Account);
