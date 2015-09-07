using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Service.Helpers;

namespace API.Core.Service.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQuestionService : IBaseServiceApi<API.Core.Repository.Models.Survey.Question, Question>
    {      
       
    }
}
