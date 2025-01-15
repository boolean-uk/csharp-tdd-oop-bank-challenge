using System;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main;

abstract class User
{
    public readonly Guid uid;
    public string name;

    public readonly Role role;

    public User(string name, Role role)
    {
        this.uid = Guid.NewGuid();
        this.name = name;
        this.role = role;
    }
}
