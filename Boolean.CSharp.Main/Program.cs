// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Interfaces;
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");
Core _core = new Core();

List<IAccount> accountslist = new List<IAccount>();

_core.CreateUser("Malimo", "123456", accountslist);
var user = _core.userList.First();
var type = AccountType.Current;


_core.creatBankAcc(user, type);

var accountname = _core.userList.First().AccountList.First();

int amount = 1000;
int amount1 = 2000;
int amount2 = 500;

_core.DepositAmount(user, amount, accountname);
_core.DepositAmount(user, amount1, accountname);
_core.WithdrawAmount(user, amount2, accountname);

_core.BankStatement(user, accountname);
