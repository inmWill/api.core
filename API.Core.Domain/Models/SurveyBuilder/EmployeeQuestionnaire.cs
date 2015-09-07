using System.Collections.Generic;
using API.Core.Domain.Models.Base;
using API.Core.Domain.Models.Clients;

namespace API.Core.Domain.Models.SurveyBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeQuestionnaire : BaseEntity
    {
        
        public int Id { get; set; }
        //public object Response { get; set; }       
        public string Response { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<AppUserInfo> Employees { get; set; }
    }
}
