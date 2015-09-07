namespace API.Core.Repository.Interfaces
{
    public interface IObjectWithState
    {
        State State { get; set; }
    }

    public enum State
    {
        Added,
        Unchanged,
        Deleted,
        Modified
    }
}