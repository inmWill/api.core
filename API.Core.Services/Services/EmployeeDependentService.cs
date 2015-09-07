using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Client;
using API.Core.Service.Helpers;
using API.Core.Service.Interfaces;
using AutoMapper;

namespace API.Core.Service.Services
{
    public class EmployeeDependentService : BaseServiceApi<EmployeeDependent, API.Core.Domain.Models.Clients.EmployeeDependent>, IEmployeeDependentService
    {

        /// <summary>
        /// Requires IRepository
        /// </summary>
        /// <param name="dataRepository"></param>
        public EmployeeDependentService(IRepository dataRepository) : base(dataRepository)
        {
            Includes = new[] { "DependentType" };
        }

        public IEnumerable<API.Core.Domain.Models.Clients.EmployeeDependent> GetPagedByExpression(Expression<Func<EmployeeDependent, bool>> filter, Expression<Func<EmployeeDependent, int>> order, int index = 0, int size = 50)
        {
            var entities = _dataRepository.PagedFilter(filter, order, index, size, Includes);
            return Mapper.Map<IEnumerable<API.Core.Domain.Models.Clients.EmployeeDependent>>(entities);
        }
    }
}
