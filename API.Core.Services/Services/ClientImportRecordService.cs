using System;
using API.Core.Domain.InputModels;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Import;
using API.Core.Service.Helpers;
using API.Core.Service.Interfaces;
using AutoMapper;

namespace API.Core.Service.Services
{
    /// <summary>
    /// Client Employee service handles client database interactions
    /// Basic CRUD operations are handled by BaseServiceApi
    /// </summary>
    public class ClientImportRecordService : BaseServiceApi<ClientImportRecord, API.Core.Domain.Models.Import.ClientImportRecord>, IClientImportRecordService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataRepository"></param>
        public ClientImportRecordService(IRepository dataRepository)
            : base(dataRepository)
        {
         //   Includes = new[] { "Dependents" };
        }

        public API.Core.Domain.Models.Import.ClientImportRecord GetClientImportRecordByRegistrationModel(AppUserRegistrationModel registrationModel)
        {

             var entity = _dataRepository.Find<ClientImportRecord>(t => t.EmployeeLastName == registrationModel.LastName
                                                                    && t.EmployeeDateOfBirth == registrationModel.DateOfBirth
                                                                    && t.EmployeeSSN.EndsWith(registrationModel.SSN), Includes);

            // ASP.Net Identity requires an email, if they don't provide one we will generate a random one.
             if (registrationModel.Email != null && entity.EmployeeEmail == null)
                 entity.EmployeeEmail = registrationModel.Email;
             else
                 entity.EmployeeEmail = Guid.NewGuid() + "@companyname.com";

            return Mapper.Map<API.Core.Domain.Models.Import.ClientImportRecord>(entity);
        }

    }
}
