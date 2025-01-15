Bank bank = new Bank();
int acc = bank.AddAccount<SavingsAccount>("bob", "savings to a Ps5");


List<Tuple<float, float, float>> deposit_withdraw_expected = new()
            {
                new(30,30,0),
                new(30,10,20),
                new(100,0,120),
                new(100,10,210),
                new(0,0,210),
                new(0,30,180),
                new(0,50,130),
                new(1,0,131),
                new(1,0,132),
                new(1,0,133),
                new(2,0,135),
                new(0,35,100),
            };

foreach (var t in deposit_withdraw_expected)
{
    float dep = t.Item1;
    float wit = t.Item2;
    float exp = t.Item3;

    if (dep != 0)

        bank.deposit(acc, dep);
    if (wit != 0)
    {
        float? returned = bank.withdraw(acc, wit);
    }
}

bank.presentAccountStatement(acc);