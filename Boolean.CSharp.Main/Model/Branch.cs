namespace Boolean.CSharp.Main;

public class Branch {
    private string _address;
    private int _sortCode;

    public Branch(string address, int sortCode) {
        _address = address;
        _sortCode = sortCode;
    }

    public int SortCode {get {return _sortCode; } }
    public string Address {get {return _address; } }

}