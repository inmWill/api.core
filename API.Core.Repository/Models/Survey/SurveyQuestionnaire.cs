using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;

namespace API.Core.Repository.Models.Survey
{
    /// <summary>
    /// 
    /// </summary>
    public class SurveyQuestionnaire : BaseEntity, IIdentifier, IObjectWithState
    {
        [Key]
        public int Id { get; set; }
                
        [Required]
        public bool IsStartingQuestion { get; set; }

        [Required]
        public bool IsEndingQuestion { get; set; }


        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual API.Core.Repository.Models.Survey.Survey Survey { get; set; }

        public State State { get; set; }
    }
}
