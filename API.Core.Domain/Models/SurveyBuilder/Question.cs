using System.Collections.Generic;
using API.Core.Domain.Models.Base;
using API.Core.Domain.Models.Clients;
using API.Core.Domain.Models.Lookup;

namespace API.Core.Domain.Models.SurveyBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class Question : BaseEntity
    {        
        public int Id { get; set; }

        public string Title { get; set; }
        public string QuestionText { get; set; }
        public string QuestionSubText { get; set; }
        public QuestionType Type { get; set; }
        public bool IsRequired { get; set; }
        public virtual Dialog Dialog { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<AppUserInfo> Employees { get; set; }

    }   
}
