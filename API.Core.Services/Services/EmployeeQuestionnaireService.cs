using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Repository.Interfaces;
using API.Core.Service.Helpers;
using API.Core.Service.Interfaces;

namespace API.Core.Service.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeQuestionnaireService : BaseServiceApi<API.Core.Repository.Models.Survey.EmployeeQuestionnaire, EmployeeQuestionnaire>, IEmployeeQuestionnaireService
    {

        public EmployeeQuestionnaireService(IRepository dataRepository)
            : base(dataRepository) { }
        
    }
}
