using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;
using API.Core.Repository.Models.Client;

namespace API.Core.Repository.Models.Survey
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeQuestionnaire : BaseEntity, IIdentifier, IObjectWithState
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        //public object Response { get; set; }

        [Required]
        public string Response { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<ClientEmployee> Employees { get; set; }
        public State State { get; set; }
    }
}
