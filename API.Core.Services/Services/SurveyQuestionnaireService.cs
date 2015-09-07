using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Repository.Interfaces;
using API.Core.Service.Helpers;
using API.Core.Service.Interfaces;

namespace API.Core.Service.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SurveyQuestionnaireService : BaseServiceApi<API.Core.Repository.Models.Survey.SurveyQuestionnaire, SurveyQuestionnaire>, ISurveyQuestionnaireService
    {
        public SurveyQuestionnaireService(IRepository dataRepository)
            : base(dataRepository) 
        {
            Includes = new[] { "Question", "Answer", "Survey" };
        }
    }
}
