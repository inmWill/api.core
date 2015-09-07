using API.Core.Domain.Models.Base;

namespace API.Core.Domain.Models.SurveyBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class SurveyQuestionnaire : BaseEntity
    {
        public int Id { get; set; }        
        public bool IsStartingQuestion { get; set; }
        public bool IsEndingQuestion { get; set; }
        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
