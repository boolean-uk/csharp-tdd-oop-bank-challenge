namespace Boolean.CSharp.Main;

public interface IOverdraftable
{
    decimal OverdraftLimit { get; set; }
    List<OverdraftRequest> OverdraftRequests { get; set; }
    
    void RequestOverdraft(decimal amount);
}