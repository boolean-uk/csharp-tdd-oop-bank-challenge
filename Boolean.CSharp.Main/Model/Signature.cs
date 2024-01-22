namespace Boolean.CSharp.Main;

public class Signature {
    private Guid _id;
    private bool _isManager;

    public Signature(bool isManager = false) {
        _id = new Guid();
        _isManager = isManager;
    }

    public Guid Id {get {return _id;}}
    public bool IsManager {get {return _isManager;}}
}