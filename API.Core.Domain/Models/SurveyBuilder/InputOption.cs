using API.Core.Domain.Enums;
using API.Core.Domain.Models.Base;

namespace API.Core.Domain.Models.SurveyBuilder
{
    public class InputOption : BaseEntity
    {        
        public int Id { get; set; }
        public string value { get; set; }

        public State State { get; set; }

    }
}
