using System.Collections.Generic;
using API.Core.Domain.Enums;
using API.Core.Domain.Models.Base;
using API.Core.Domain.Models.Clients;

namespace API.Core.Domain.Models.SurveyBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeSurveyAudit : BaseEntity
    {        
        public int Id { get; set; }

        public SurchargeResultType Result { get; set; }
        public ICollection<EmployeeQuestionnaire> EmployeeSurveyResponse { get; set; }
        public virtual AppUserInfo Employee { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
