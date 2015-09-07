using System.Collections.Generic;

namespace API.Core.Domain.ViewModels
{
    public class SurveyQuestionViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string HelpText { get; set; }
        public string Type { get; set; }
       
        public virtual ICollection<SurveyAnswerViewModel> Answers { get; set; }
        
    }
}