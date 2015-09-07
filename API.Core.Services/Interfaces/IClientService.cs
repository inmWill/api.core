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
    public interface IClientService : IBaseServiceApi<Client, API.Core.Domain.Models.Clients.Client>
    {
        API.Core.Domain.Models.Clients.Client GetByEmail(string email);

        IEnumerable<API.Core.Domain.Models.Clients.Client> GetPagedClientsByExpression(Expression<Func<Client, bool>> filter, Expression<Func<Client, int>> order, int index = 0, int size = 50);
    }
}
