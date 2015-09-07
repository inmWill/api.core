using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Repository.Interfaces;
using API.Core.Service.Helpers;
using API.Core.Service.Interfaces;

namespace API.Core.Service.Services
{
    public class AnswerService : BaseServiceApi<API.Core.Repository.Models.Survey.Answer, Answer>, IAnswerService
    {
        public AnswerService(IRepository dataRepository)
            : base(dataRepository) { Includes = new[] { "Unit", "Values", "InputOptionType" }; }
       

       
    }
}
