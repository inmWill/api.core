using API.Core.Domain.Models.Base;

namespace API.Core.Domain.Models.SurveyBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class Dialog : BaseEntity
    {
   
        public int Id { get; set; }
        public string DialogText { get; set; }
    }
}
