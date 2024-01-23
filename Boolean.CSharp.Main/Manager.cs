namespace Boolean.CSharp.Main;

public class Manager
{
    private List<OverdraftRequest> _overdraftRequests;

    public Manager()
    {
        _overdraftRequests = new List<OverdraftRequest>();
    }

    public void addOverdraftRequest(OverdraftRequest request)
    {
        _overdraftRequests.Add(request);
    }

    public OverdraftRequest? getOverdraftRequestById(int id)
    {
        return _overdraftRequests.FirstOrDefault(x => x.Id == id);
    }
}
