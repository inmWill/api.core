using System.Collections.Generic;
using API.Core.Domain.Enums;
using API.Core.Domain.Models.Base;
using OperatorType = API.Core.Domain.Models.Lookup.OperatorType;
using UnitOfMeasure = API.Core.Domain.Models.Lookup.UnitOfMeasure;

namespace API.Core.Domain.Models.SurveyBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class SkipLogicRule : BaseEntity
    {

        public int Id { get; set; }
        public UnitOfMeasure Unit { get; set; } // don't need this one

        //public object ValidAnswer { get; set; }

        public string ValidAnswer { get; set; }
        public OperatorType OperatorType { get; set; }        
        public int NextQuestionId { get; set; }        
        public bool TriggerDialog { get; set; }

        public virtual ICollection<Dialog> Dialogs { get; set; }
        public virtual Question Question { get; set; }        
        public virtual Question NextQuestion { get; set; }
        public State State { get; set; }

        public virtual Survey Survey { get; set; }

        //Add complex rule domain later
    }
}
