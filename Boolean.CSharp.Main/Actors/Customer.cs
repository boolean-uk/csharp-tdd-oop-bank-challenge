using System;

namespace Boolean.CSharp.Main.Actors;

public class Customer : Actor
{
    public Customer(SpareBank bank) : base(bank)
    {
       
    }

    public override bool AcceptOverdraft(Account account)
    {
        return false;
    }
}
