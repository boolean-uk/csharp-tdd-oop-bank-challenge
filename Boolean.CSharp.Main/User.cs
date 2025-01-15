using System;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main;

public abstract class User
{
    public readonly Guid userId;
    public string name;

    public readonly Role role;

    public User(string name, Role role)
    {
        this.userId = Guid.NewGuid();
        this.name = name;
        this.role = role;
    }
}
