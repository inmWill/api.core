using System.Collections.Generic;
using API.Core.Domain.InputModels;
using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Service.Helpers;

namespace API.Core.Service.Interfaces
{
    public interface ISkipLogicRuleService : IBaseServiceApi<API.Core.Repository.Models.Survey.SkipLogicRule, SkipLogicRule>
    {
        IEnumerable<SkipLogicRule> GetNextRule(EmployeeResponseModel response);
    }
}
