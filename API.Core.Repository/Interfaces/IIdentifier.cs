namespace API.Core.Repository.Interfaces
{
    /// <summary>
    /// Used to facilitate the expression predicate in the base service api
    /// </summary>
    public interface IIdentifier
    {
        /// <summary>
        /// Reflected to EF primary key
        /// </summary>
        int Id { get; set; }
    }
}
