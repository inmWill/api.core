using System.Collections.Generic;
using API.Core.Domain.Enums;
using API.Core.Domain.Models.Base;
using InputOptionType = API.Core.Domain.Models.Lookup.InputOptionType;
using UnitOfMeasure = API.Core.Domain.Models.Lookup.UnitOfMeasure;

namespace API.Core.Domain.Models.SurveyBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class Answer : BaseEntity
    {        
        public int Id { get; set; }     
        public virtual InputOptionType InputOptionType { get; set; }       
        public virtual UnitOfMeasure Unit { get; set; }
        public string DisclaimerText { get; set; }
        public string LinkText { get; set; }
        public string Style { get; set; }
        public State State { get; set; }
        public virtual ICollection<InputOption> Values { get; set; }
    }


}
