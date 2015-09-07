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
    /// <summary>
    /// Client service handles client database interactions
    /// Basic CRUD operations are handled by BaseServiceApi
    /// </summary>
    public class ClientService : BaseServiceApi<Client, API.Core.Domain.Models.Clients.Client>, IClientService
    {
        /// <summary>
        /// Requires IRepository
        /// </summary>
        /// <param name="dataRepository"></param>
        public ClientService(IRepository dataRepository) : base(dataRepository)
        {
        }

        public API.Core.Domain.Models.Clients.Client GetByEmail(string email)
        {
            var entity = _dataRepository.Find<Client>(t => t.Email == email, Includes);
            return Mapper.Map<API.Core.Domain.Models.Clients.Client>(entity);
        }

        public IEnumerable<API.Core.Domain.Models.Clients.Client> GetPagedClientsByExpression(Expression<Func<Client, bool>> filter, Expression<Func<Client, int>> order, int index = 0, int size = 50)
        {
            var entities = _dataRepository.PagedFilter(filter, order, index, size, Includes);
            return Mapper.Map<IEnumerable<API.Core.Domain.Models.Clients.Client>>(entities);
        }
    }
}
