using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;
using API.Core.Repository.Models.Lookup;

namespace API.Core.Repository.Models.Survey
{
    /// <summary>
    /// 
    /// </summary>
    public class SkipLogicRule : BaseEntity, IIdentifier, IObjectWithState
    {
        [Key]
        public int Id { get; set; }
                        
        public virtual UnitOfMeasure Unit { get; set; } // don't need this one
                
        //public object ValidAnswer { get; set; }

        public string ValidAnswer { get; set; }
        
        public virtual OperatorType OperatorType { get; set; }
        
        public int? NextQuestionId { get; set; }
        
        [Required]
        public bool TriggerDialog { get; set; }

        public virtual ICollection<Dialog> Dialogs { get; set; }                
        
        public virtual Question Question { get; set; }
       
        [ForeignKey("NextQuestionId")]
        public virtual Question NextQuestion { get; set; }
        
        public virtual Survey Survey { get; set; }

        public State State { get; set; }
    }
}
