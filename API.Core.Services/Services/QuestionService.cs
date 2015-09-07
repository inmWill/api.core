using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Repository.Interfaces;
using API.Core.Service.Helpers;
using API.Core.Service.Interfaces;

namespace API.Core.Service.Services
{
    /// <summary>
    /// Question Service
    /// </summary>
    public class QuestionService : BaseServiceApi<API.Core.Repository.Models.Survey.Question, Question>, IQuestionService
    {

        public QuestionService(IRepository dataRepository)
            : base(dataRepository)
        {
            Includes = new[] { "Answers" };
        }
       
    }
}
