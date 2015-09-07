using System.Collections.Generic;

namespace API.Core.Domain.ViewModels
{
    public class SurveyQuestionnaireViewModel
    {
        public int Id { get; set; }
        public bool IsStartingQuestion { get; set; }
        public bool IsEndingQuestion { get; set; }
        public virtual ICollection<SurveyQuestionViewModel> Questionnaires { get; set; }
    }
}
