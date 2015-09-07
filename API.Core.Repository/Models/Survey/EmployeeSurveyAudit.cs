using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Core.Domain.Enums;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;
using API.Core.Repository.Models.Client;
using State = API.Core.Repository.Interfaces.State;

namespace API.Core.Repository.Models.Survey
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeSurveyAudit : BaseEntity, IIdentifier, IObjectWithState
    {
        [Key]
        public int Id { get; set; }

        public SurchargeResultType Result { get; set; }
        public ICollection<EmployeeQuestionnaire> EmployeeSurveyResponse { get; set; }

        public virtual ClientEmployee Employee { get; set; }
        public virtual Survey Survey { get; set; }
        public State State { get; set; }
    }
}
