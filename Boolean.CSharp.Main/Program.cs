using Boolean.CSharp.Source;

CurrentAccount account = new CurrentAccount();
account.DepositMoney(1000M);
account.WithdrawMoney(500M);

account.BankStatement();
