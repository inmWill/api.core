using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using API.Core.Domain.InputModels;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Client;
using API.Core.Service.Helpers;
using API.Core.Service.Interfaces;
using AutoMapper;

namespace API.Core.Service.Services
{
    /// <summary>
    /// Client Employee service handles client database interactions
    /// Basic CRUD operations are handled by BaseServiceApi
    /// </summary>
    public class ClientEmployeeService : BaseServiceApi<ClientEmployee, API.Core.Domain.Models.Clients.AppUserInfo>, IClientEmployeeService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRepository"></param>
        public ClientEmployeeService(IRepository dataRepository): base(dataRepository)
        {
           Includes = new[] { "Dependents" };
        }

        public API.Core.Domain.Models.Clients.AppUserInfo GetByEmail(string email)
        {
            var entity = _dataRepository.Find<ClientEmployee>(t => t.CompanyEmail == email, Includes);
            return Mapper.Map<API.Core.Domain.Models.Clients.AppUserInfo>(entity);
        }

        public IEnumerable<API.Core.Domain.Models.Clients.AppUserInfo> GetPagedClientEmployeesByExpression(Expression<Func<ClientEmployee, bool>> filter, Expression<Func<ClientEmployee, int>> order, int index = 0, int size = 50)
        {
            var entities = _dataRepository.PagedFilter(filter, order, index, size, Includes);
            return Mapper.Map<IEnumerable<API.Core.Domain.Models.Clients.AppUserInfo>>(entities);

            
        }

        public API.Core.Domain.Models.Clients.AppUserInfo GetClientEmployeeRecordByRegistrationModel(AppUserRegistrationModel registrationModel)
        {
            var entity = _dataRepository.Find<ClientEmployee>(t => t.CompanyEmail == registrationModel.Email 
                                                                && t.LastName == registrationModel.LastName 
                                                                && t.DateOfBirth == registrationModel.DateOfBirth
                                                                && t.LastSSN == registrationModel.SSN, Includes);
            return Mapper.Map<API.Core.Domain.Models.Clients.AppUserInfo>(entity);
        }

    }
}
