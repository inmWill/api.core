using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Service.Helpers;

namespace API.Core.Service.Interfaces
{
    public interface ISurveyService : IBaseServiceApi<API.Core.Repository.Models.Survey.Survey, Survey>
    {
        void GetSurveyByEmployee(int EmployeeId);
        Survey GetActiveClientSurvey(int clientId);
    }
}
