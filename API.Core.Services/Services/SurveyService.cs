using System;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Survey;
using API.Core.Service.Helpers;
using API.Core.Service.Interfaces;
using AutoMapper;

namespace API.Core.Service.Services
{
    public class SurveyService : BaseServiceApi<Survey, API.Core.Domain.Models.SurveyBuilder.Survey>, ISurveyService
    {

        public SurveyService(IRepository dataRepository) 
            : base(dataRepository)
        {

        }

        public void GetSurveyByEmployee(int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public API.Core.Domain.Models.SurveyBuilder.Survey GetActiveClientSurvey(int clientId)
        {
            var entity = _dataRepository.Find<Survey>(s => s.Client.Id == clientId && s.Active, Includes);
            return Mapper.Map<API.Core.Domain.Models.SurveyBuilder.Survey>(entity);
        }

    }
}
