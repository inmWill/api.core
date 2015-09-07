using System;

namespace API.Core.Repository.Interfaces
{
    /// <summary>
    /// Tells the generic repository to set a time stamp
    /// </summary>
    public interface ICreatedOn
    {
        DateTime CreatedOn { get; set; }
    }
}
