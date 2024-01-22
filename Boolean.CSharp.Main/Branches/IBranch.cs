using Boolean.CSharp.Main.Models;

namespace Boolean.CSharp.Main.Branches
{
    public interface IBranch
    {
        public string Name { get; }
        public string Description { get; }
        public List<Request> Requests { get; }
        public void ReviewRequests();
    }
}