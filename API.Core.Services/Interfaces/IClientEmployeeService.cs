using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using API.Core.Domain.InputModels;
using API.Core.Repository.Models.Client;
using API.Core.Service.Helpers;

namespace API.Core.Service.Interfaces
{
    /// <summary>
    /// Client Business Services
    /// Base crud provided by BaseServiceApi
    /// Extend this interface to add new features
    /// </summary>
    public interface IClientEmployeeService : IBaseServiceApi<ClientEmployee, API.Core.Domain.Models.Clients.AppUserInfo>
    {
        API.Core.Domain.Models.Clients.AppUserInfo GetByEmail(string email);
        API.Core.Domain.Models.Clients.AppUserInfo GetClientEmployeeRecordByRegistrationModel(AppUserRegistrationModel registrationModel);

        IEnumerable<API.Core.Domain.Models.Clients.AppUserInfo> GetPagedClientEmployeesByExpression(Expression<Func<ClientEmployee, bool>> filter, Expression<Func<ClientEmployee, int>> order, int index = 0, int size = 50);
    }
}
