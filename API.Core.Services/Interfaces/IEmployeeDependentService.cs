using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using API.Core.Repository.Models.Client;
using API.Core.Service.Helpers;

namespace API.Core.Service.Interfaces
{
    /// <summary>
    /// Client Business Services
    /// Base crud provided by BaseServiceApi
    /// Extend this interface to add new features
    /// </summary>
    public interface IEmployeeDependentService : IBaseServiceApi<EmployeeDependent, API.Core.Domain.Models.Clients.EmployeeDependent>
    {
        IEnumerable<API.Core.Domain.Models.Clients.EmployeeDependent> GetPagedByExpression(Expression<Func<EmployeeDependent, bool>> filter, Expression<Func<EmployeeDependent, int>> order, int index = 0, int size = 50);
    }
}
