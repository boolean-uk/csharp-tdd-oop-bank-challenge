using Boolean.CSharp.Main;

Core _core = new Core();

List<List<Transaction>> accountslist = new List<List<Transaction>>();
_core.CreateUser("Max", "password", accountslist);
var user = _core.UserList.First();
var type = AccountType.Current;
var branch = BankBranchType.Amsterdam;

_core.CreateBankAccount(user, type, branch);

var accountname = _core.UserList.First().AccountsList.First();

int amount = 1000;
int amount1 = 2000;
int amount2 = 500;

_core.DepositAmount(user, amount, accountname);
_core.DepositAmount(user, amount1, accountname);
_core.WithdrawAmount(user, amount2, accountname);

_core.BankStatement(user, accountname);
