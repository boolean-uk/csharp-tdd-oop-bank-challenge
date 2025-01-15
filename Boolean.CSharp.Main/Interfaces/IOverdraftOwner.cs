// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

public interface IOverdraftOwner
{
    void setConfigFunc(Overdraft overdraft, Action<float> configOverdraft, Account acc);
}