using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;
using API.Core.Repository.Models.Lookup;

namespace API.Core.Repository.Models.Survey
{
    /// <summary>
    /// 
    /// </summary>
    public class Answer : BaseEntity, IIdentifier, IObjectWithState
    {
        [Key]
        public int Id { get; set; }

        //[Required] 
        //public InputOptionType InputOptionTypeId { get; set; }                

        public virtual InputOptionType InputOptionType { get; set; }

        //[Required]
        //public UnitOfMeasure Unit { get; set; }

        public virtual UnitOfMeasure Unit { get; set; }

        public string DisclaimerText { get; set; }

        public string LinkText { get; set; }
        public string Style { get; set; }

        public State State { get; set; }
        //public ICollection<object> Values { get; set; }
        public virtual ICollection<InputOption> Values { get; set; }
    }
}
