using System;
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
    public class Survey : BaseEntity, IIdentifier, IObjectWithState
    {
        public Survey()
        {
            this.Questions = new HashSet<Question>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public string Instructions { get; set; }
        
        public string OtherInfo { get; set; }

        public bool Active { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public virtual ICollection<ClientEmployee> Employees { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        
        public virtual API.Core.Repository.Models.Client.Client Client { get; set; }
        public State State { get; set; }
    }
}
