using System;

namespace Boolean.CSharp.Main.Actors;

public class Manager : Actor
{
    public Manager(SpareBank bank) : base(bank)
    {
    }

    public override bool AcceptOverdraft(Account account)
    {
        return BankService.AcceptOverdraft(account);
    }
}
