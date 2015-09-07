using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;
using API.Core.Repository.Models.Client;
using API.Core.Repository.Models.Lookup;

namespace API.Core.Repository.Models.Survey
{
    /// <summary>
    /// 
    /// </summary>
    public class Question : BaseEntity, IIdentifier, IObjectWithState
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string QuestionText { get; set; }
        
        [MaxLength(500)]
        public string QuestionSubText { get; set; }
        
        public virtual QuestionType Type { get; set; }        
        
        [Required]
        public bool IsRequired { get; set; }
        
        public virtual Dialog Dialog { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<ClientEmployee> Employees { get; set; }
        public State State { get; set; }
    }   
}
